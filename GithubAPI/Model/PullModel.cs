using GithubAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubAPI.Model
{
    public class PullModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public UserModel User { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime? Closed_at { get; set; }
        public DateTime? Merged_at { get; set; }
        public string RepoFullName => Head?.Repo?.full_name;
        public Head Head { get; set; }


        public static explicit operator Pull(PullModel model)
        {
            return new Pull
            {
                IdPull = model.Id,
                Closed_at = model.Closed_at,
                Created_at = model.Created_at,
                Merged_at = model.Merged_at,
                Number = model.Number,
                RepoFullName = model.Head?.Repo?.full_name,
                Title = model.Title,
                Updated_at = model.Updated_at,
                Url = model.Url,
                UserId = model.User?.Id != null ? model.User.Id : 0,
                User = (User)model.User
            };
        }
    }
    public class Repo
    {
        public string full_name { get; set; }
    }

    public class Head
    {
        public Repo Repo { get; set; }
    }
}
