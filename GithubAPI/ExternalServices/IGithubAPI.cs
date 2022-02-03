using GithubAPI.Entities;
using GithubAPI.Model;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubAPI.ExternalServices
{
    public interface IGithubAPI
    {
        [Get("/repos/{owner}/{repo}/pulls?state={state}&per_page={total_per_page}&page={page_number}")]
        Task<List<PullModel>> GetPullsAsync(string owner, string repo, string state, int total_per_page, int page_number);

        [Get("/repos/{owner}/{repo}/pulls/{pull_number}/reviews")]
        Task<List<ReviewModel>> GetReviewsAsync(string owner, string repo, int pull_number);
    }
}
