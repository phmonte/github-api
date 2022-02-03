using GithubAPI.Context;
using GithubAPI.Entities;
using GithubAPI.ExternalServices;
using GithubAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubAPI.Service.Database
{
    public class PullDatabase : IGithubDataService
    {
        private readonly IGithubAPI _githubAPIRepository;
        private readonly DataContext _dataContext;
        public PullDatabase(IGithubAPI githubAPIRepository, DataContext dataContext)
        {
            _githubAPIRepository = githubAPIRepository;
            _dataContext = dataContext;
        }

        public async Task UpdateDatabase(string[] data)
        {
            var groupSelected = _dataContext.Group.Include(x => x.Repository).Where(x => x.Name == data[0]).FirstOrDefault();

            var pullSaved = new List<Pull>();
            foreach (var item in groupSelected.Repository)
            {
                pullSaved.AddRange(_dataContext.Pull.Where(x => x.Url.Contains($"{item.Owner}/{item.Name}")).ToList());
            }

            for (int i = 0; i < groupSelected.Repository.Count; i++)
            {
                Pull pullDataBasefound = null;
                List<PullModel> pulls = new List<PullModel>();
                var r = 1;
                while (r == 1 || (pullDataBasefound == null && pulls.Count > 0))
                {
                    pulls = await _githubAPIRepository.GetPullsAsync(groupSelected.Repository[i].Owner, groupSelected.Repository[i].Name, "all", 100, r);

                    if (pulls.Count == 0)
                        break;

                    var j = 0;
                    while (pullDataBasefound == null && j < pulls.Count)
                    {
                        pullDataBasefound = pullSaved.Where(x => x.Number == pulls[j].Number && x.RepoFullName == $"{groupSelected.Repository[i].Owner}/{groupSelected.Repository[i].Name}").FirstOrDefault();
                        if (pullDataBasefound == null)
                        {
                            var parentGambs = (Pull)pulls[j];
                            var childGambs = parentGambs.User;
                            parentGambs.User = null;

                            var exists = _dataContext.User.Where(x => x.Id == childGambs.Id).AsNoTracking().FirstOrDefault();

                            if (exists == null)
                            {
                                await _dataContext.User.AddAsync(childGambs);
                            }
                            await _dataContext.Pull.AddAsync(parentGambs);
                            await _dataContext.SaveChangesAsync();
                        }
                        j++;
                    }
                    r++;
                }
            }
        }
    }
}
