using GithubAPI.Context;
using GithubAPI.DTOs;
using GithubAPI.Entities;
using GithubAPI.ExternalServices;
using GithubAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubAPI.Controllers
{
    [Route("api/pull")]
    [ApiController]
    public class PullController : ControllerBase
    {
        private readonly IGithubAPI _githubAPIRepository;
        private readonly DataContext _dataContext;
        public PullController(IGithubAPI githubAPIRepository, DataContext dataContext)
        {
            _githubAPIRepository = githubAPIRepository;
            _dataContext = dataContext;
        }


        [HttpGet("{group}/approver/ranking")]
        public async Task<List<PRUserReview>> GetRankingPullApprover(string group)
        {
            var result = new List<PRUserReview>();

            var query = await _dataContext.Review
                .Where(x => x.State == "APPROVED")
                .GroupBy(x => new { x.User.Login })
                .Select(g => new PRUserReview { Login = g.Key.Login, TotalApprove = g.Count() })
                .OrderByDescending(x => x.TotalApprove)
                .ToListAsync();

            return query;
        }
        [HttpGet("{group}/approver/ranking/{Start}/{End}")]
        public async Task<List<PRUserReview>> GetRankingPullApproverBydate(DateTime Start, DateTime End)
        {
            var result = new List<PRUserReview>();

            var query = await _dataContext.Review
                .Where(x => x.State == "APPROVED" && x.Pull.Created_at >= Start && x.Pull.Created_at <= End)
                .GroupBy(x => new { x.User.Login })
                .Select(g => new PRUserReview { Login = g.Key.Login, TotalApprove = g.Count() })
                .OrderByDescending(x => x.TotalApprove)
                .ToListAsync();

            return query;
        }
    }
}
