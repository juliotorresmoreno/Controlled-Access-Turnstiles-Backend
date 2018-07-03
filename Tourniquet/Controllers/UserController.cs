using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tourniquet.Models;

namespace Tourniquet.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        DbContext db = new DbContext();
        // GET api/user
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.User;
        }

        // GET api/user/5
        [HttpGet("{document}")]
        public IEnumerable<User> Get(string document)
        {
            IEnumerable<User> user = db.User
            .Where(b => b.Document.Equals(document))
            .ToList<User>();
            return user;
        }

        // POST api/user
        [HttpPost]
        public User Post([FromBody]User data)
        {
            db.User.Add(data);
            db.SaveChanges();
            return data;
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public dynamic Put(int id, [FromBody]User data)
        {
            var existingStudent = db.User.Where(s => s.Id == id).FirstOrDefault<User>();
            if (existingStudent != null)
            {
                existingStudent.Name = data.Name;
                existingStudent.Document = data.Document;

                db.SaveChanges();
                data.Id = id;
                return data;
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
