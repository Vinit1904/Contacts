using Contacts.Model;
using Contacts.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contacts.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IContact contactRepos;
        public UserController(IContact _contactRepos)
        {
            contactRepos = _contactRepos;

        }

        // GET: api/<contactController>
        [HttpGet]
        public List<Users> Get()
        {
            return contactRepos.GetAllConatct();
        }

        // GET api/<contactController>/5
        [HttpGet("{mobileNo}")]
        public Users Get(int mobileNo)
        {
            return contactRepos.GetContactByMobileNo(mobileNo);
        }

        // POST api/<contactController>
        [HttpPost]
        public void Post([FromBody] Users users)
        {
            contactRepos.AddContact(users);
        }

        // PUT api/<contactController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<contactController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
