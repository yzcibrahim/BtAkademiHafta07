using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WordMasterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LangController : ControllerBase
    {
        readonly IRepositoryLanguage _repository;
        public LangController(IRepositoryLanguage repository)
        {
            _repository = repository;
        }

        // GET: api/<LangController>
        [HttpGet]
        public IEnumerable<Language> Get()
        {
            return _repository.List();
        }

        // GET api/<LangController>/5
        [HttpGet("{id}")]
        public Language Get(int id)
        {
            return _repository.GetById(id);
        }

        // POST api/<LangController>
        [HttpPost]
        public void Post([FromBody] Language entity)
        {
            _repository.Add(entity);
        }

        // PUT api/<LangController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Language entity)
        {
            entity.Id = id;
            _repository.Update(entity);
        }

        // DELETE api/<LangController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
