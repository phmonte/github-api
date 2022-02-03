using GithubAPI.Context;
using GithubAPI.Entities;
using GithubAPI.ExternalServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubAPI.Service.Database
{
    public class ReviewDatabase : IGithubDataService
    {
        private readonly IGithubAPI _githubAPIRepository;
        private readonly DataContext _dataContext;
        public ReviewDatabase(IGithubAPI githubAPIRepository, DataContext dataContext)
        {
            _githubAPIRepository = githubAPIRepository;
            _dataContext = dataContext;
        }

        public async Task UpdateDatabase(string[] data)
        {
            var pullsWithoutReview = await _dataContext.Pull.Include(x => x.Reviews).Where(p => p.Reviews.Count == 0 && p.ReviewSearched != true).ToListAsync();

            foreach (var pull in pullsWithoutReview)
            {
                var owner = pull.Url.Split('/')[4];
                var repo = pull.Url.Split('/')[5];
                var reviews = await _githubAPIRepository.GetReviewsAsync(owner, repo, pull.Number);

                if (reviews.Any())
                {
                    foreach (var item in reviews)
                    {
                        if (item.User != null)
                        {
                            var existsUSer = _dataContext.User.Where(x => x.Id == item.User.Id).AsNoTracking().FirstOrDefault();

                            if (existsUSer == null)
                            {
                                await _dataContext.User.AddAsync((User)item.User);
                            }

                            item.UserId = item.User.Id;
                            item.User = null;
                            var review = (Review)item;
                            review.PullNumber = pull.Number;
                            review.PullId = pull.Id;
                            await _dataContext.Review.AddAsync(review);
                            await _dataContext.SaveChangesAsync();
                        }
                    }
                    pull.ReviewSearched = true;
                    _dataContext.Pull.Update(pull);
                }
                else
                {
                    if(pull.Closed_at != null)
                    {
                        pull.ReviewSearched = true;
                        _dataContext.Pull.Update(pull);
                        await _dataContext.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
