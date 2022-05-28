using AccountApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="admin")]
    public class AccountController : ControllerBase
    {
        WordMasterDbContext _context;
        public AccountController(WordMasterDbContext context)
        {
            _context = context;
        }
        // GET: api/<AccountController>
        [HttpGet]
      
        public IEnumerable<UserAccount> Get()
        {
            return _context.UserAccounts.ToList();
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public UserAccount Get(int id)
        {
            return _context.UserAccounts.FirstOrDefault(c => c.Id == id);
        }

        // POST api/<AccountController>
        [HttpPost]
        
        public void Post([FromBody] UserAccount entity)
        {
            if(entity.Id>0)
            {
                _context.UserAccounts.Attach(entity);
                _context.Entry<UserAccount>(entity).State = EntityState.Modified;
            }
            else
            {
                _context.UserAccounts.Add(entity);
            }
            _context.SaveChanges();
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var existingAccount = _context.UserAccounts.FirstOrDefault(c => c.Id == id);
            _context.UserAccounts.Remove(existingAccount);
            _context.SaveChanges();

        }

        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public string Authenticate([FromBody] UserAccount entity)
        {
            var existing = _context.UserAccounts.FirstOrDefault(c => c.Password == entity.Password && c.UserName == entity.UserName);

            if(existing!=null)
            {

                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenKey = Encoding.ASCII.GetBytes("özel bir anahtar asd");

                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, existing.UserName),
                        new Claim(ClaimTypes.Role, existing.UserRole)

                    }),
                    Expires = DateTime.UtcNow.AddHours(1),

                    SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                //4. Create Token
                var token = tokenHandler.CreateToken(tokenDescriptor);

                // 5. Return Token from method
                string tknResult= tokenHandler.WriteToken(token);


                return tknResult;
            }

            return "";
        }
    }
}
