using GithubAPI.Context;
using GithubAPI.Service.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubAPI.Controllers
{
    [Route("api/database")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IEnumerable<IGithubDataService> _githubDataService;

        public DatabaseController(IEnumerable<IGithubDataService> githubDataService, DataContext dataContext)
        {
            _githubDataService = githubDataService;
            _dataContext = dataContext;
        }

        [HttpPost("sync")]
        public async Task DatabaseUpdate()
        {
            var groups = await _dataContext.Group.Select(x => x.Name).ToListAsync();

            foreach (var group in groups)
            {
                foreach (var databaseService in _githubDataService)
                {
                    await databaseService.UpdateDatabase(new[] { group });
                }
            }
        }

        [HttpPost("migration")]
        public async Task DatabaseApplyMigration()
        {
            await _dataContext.Database.MigrateAsync();

            if (!_dataContext.Group.Any())
            {
                await _dataContext.Group.AddAsync(Seed.GroupSeed());
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
