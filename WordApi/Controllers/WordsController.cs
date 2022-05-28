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
        WordMasterDbContext _context;
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


    }
}

