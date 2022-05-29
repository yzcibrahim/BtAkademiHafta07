using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordApi.Dtos;
using WordApi.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WordApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        WordMasterDbContext  _context;
        public WordsController(WordMasterDbContext context)
        {
            _context = context;
        }
        // GET: api/<WordsController>
        [HttpGet("{pageNum}/{pageCount}/{keyword?}")]
       // [Authorize]
        public WordDefListResult Get(int pageNum=1, int pageCount=3, string keyword = "")
        {
            WordDefListResult res = new WordDefListResult();

            if (pageNum < 1) pageNum = 1;
            if (pageCount <= 0) pageCount = 3;
            int skip = (pageNum-1) * pageCount;
            var result = _context.WordDefinitions.Include(c => c.Meanings).Where(c=>c.Word.Contains(keyword)).Skip(skip).Take(pageCount).ToList();


            double totalRecords=_context.WordDefinitions.Count(c=>c.Word.Contains(keyword));

            res.Liste = result;
            res.TotalPageCount = (int)Math.Ceiling(totalRecords / pageCount);


            return res;
          
        }

        // GET api/<WordsController>/5
        [HttpGet("{id}")]
        public WordDefinition Get(int id)
        {
            return _context.WordDefinitions.Include(c => c.Meanings).FirstOrDefault(c=>c.Id==id);
        }

        // POST api/<WordsController>
        [HttpPost]
        public IActionResult Post([FromBody] WordDefinition entity)
        {
            _context.WordDefinitions.Add(entity);
            _context.SaveChanges();
            return new CreatedResult("", "Başarıyla Kaydedildi");
            // return new StatusCodeResult(201);
        }

        // PUT api/<WordsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] WordDefinition entity)
        {
            entity.Id = id;
            _context.WordDefinitions.Attach(entity);
            _context.Entry<WordDefinition>(entity).State = EntityState.Modified;

            foreach(var meaning in entity.Meanings)
            {
                
                if (meaning.Id > 0)
                {
                    _context.WordMeanings.Attach(meaning);
                    _context.Entry<WordMeaning>(meaning).State = EntityState.Modified;
                }
                else
                {
                    _context.WordMeanings.Add(meaning);
                }
            }

            _context.SaveChanges();

        }

        // DELETE api/<WordsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var silinecek = _context.WordDefinitions.Include(c=>c.Meanings).FirstOrDefault(c=>c.Id==id);

            if(silinecek==null)
            {

                return NotFound("Kayıt Bulunamadı");
            }

            foreach(var meaning in silinecek.Meanings)
            {
                _context.WordMeanings.Remove(meaning);
            }

            _context.WordDefinitions.Remove(silinecek);
            _context.SaveChanges();

            return Ok(true);
        }

        [HttpDelete("meaning/{id}")]
        public void DeleteMeaning(int id)
        {
            var silinecek = _context.WordMeanings.FirstOrDefault(c => c.Id == id);
            _context.WordMeanings.Remove(silinecek);
            _context.SaveChanges();
        }


        [HttpGet("getRandom/{rowNum}")]
        public WordDefinition GetRandomWord(int rowNum)
        {
           return _context.WordDefinitions.Skip(rowNum - 1).Take(1).FirstOrDefault();

        }

        [HttpGet("CheckAnswer/{answer}/{wordDefId}/{testcount}")]
        [Authorize]
        public CheckAnswerResultDto CheckAnswer(string answer, int wordDefId, int testcount)
        {
            
            CheckAnswerResultDto res = new CheckAnswerResultDto();
            res.TestCount = testcount;

            if (_context.WordMeanings.Any(c => c.WordDefinitionId == wordDefId && c.Meaning.ToUpper() == answer.ToUpper()))
            {
                res.Result = true;
            }
            else
            {
                res.Result = false;
            }

            var userName = Request.HttpContext.User.Identity.Name;
            var existing = _context.AnswerStastistics.FirstOrDefault(c => c.Username == userName && c.WordDefId == wordDefId);
            if (existing==null)
            {
                AnswerStastistic entity = new AnswerStastistic();
                entity.AskCount = 1;
                entity.CorrectCount = res.Result ? 1 : 0;
                entity.Username = userName;
                entity.WordDefId = wordDefId;
                _context.AnswerStastistics.Add(entity);
                _context.SaveChanges();
            }
            else
            {
                existing.AskCount++;
                existing.CorrectCount= res.Result ? existing.CorrectCount+1 : existing.CorrectCount;
                _context.SaveChanges();
            }

            int totalRecord = _context.WordDefinitions.Count();
            if (res.TestCount%3==0)
            {
                Random rnd1 = new Random();
                var rndRes = rnd1.Next(0, totalRecord);
                res.WordDef = _context.WordDefinitions.Skip(rndRes).Take(1).First();
                return res;
            }

            var totalAsks = _context.AnswerStastistics.Where(c => c.Username == userName).ToList();
            
            Dictionary<int, double> wordStatistic = new Dictionary<int, double>();
            var existingWords = _context.WordDefinitions.ToList();
            
            foreach(var item in existingWords)
            {
                var existingStatistic = totalAsks.FirstOrDefault(c => c.WordDefId == item.Id);
                if (existingStatistic == null)
                    wordStatistic.Add(item.Id, 100);
                else
                {
                    var oran = (double)(existingStatistic.AskCount - existingStatistic.CorrectCount) / (double)existingStatistic.AskCount * 100;
                    wordStatistic.Add(item.Id, oran);
                }
            }

            List<int> wordsToAsk = wordStatistic.Where(c=>c.Key!=wordDefId).OrderByDescending(c => c.Value).Select(c=>c.Key).Take(3).ToList();

            Random rnd = new Random();
            int rowNum=rnd.Next(0, 2);
            var lastId = wordsToAsk[rowNum];
            res.WordDef = _context.WordDefinitions.First(c=>c.Id==lastId);

            return res;
        }




    }
}

