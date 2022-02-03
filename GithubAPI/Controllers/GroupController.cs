using GithubAPI.Context;
using GithubAPI.Entities;
using GithubAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GithubAPI.Controllers
{
    [Route("api/group")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public GroupController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET: api/<GroupController>
        [HttpGet]
        public async Task<List<Group>> Get()
        {
            return _dataContext.Group.Include(x => x.Repository).ToList();
        }

        // GET api/<GroupController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> Get(int id)
        {
            return await _dataContext.Group.Include(x => x.Repository).Where(x => x.Id == id).FirstOrDefaultAsync(); ;
        }

        // POST api/<GroupController>
        [HttpPost]
        public async Task Post([FromBody] Group Group)
        {
            await _dataContext.Group.AddAsync(Group);
            await _dataContext.SaveChangesAsync();
        }

        // PUT api/<GroupController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GroupController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
