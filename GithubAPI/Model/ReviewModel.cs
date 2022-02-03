using GithubAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubAPI.Model
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public int UserId { get; set; }
        public string Body { get; set; }
        public string State { get; set; }
        public string Html_url { get; set; }
        public string Pull_request_url { get; set; }
        public string Author_association { get; set; }
        public DateTime Submitted_at { get; set; }

        public static explicit operator Review(ReviewModel model)
        {
            return new Review
            {
                Id = model.Id,
                Author_association = model.Author_association,
                Body = model.Body,
                Html_url = model.Html_url,
                Pull_request_url = model.Pull_request_url,
                State = model.State,
                Submitted_at = model.Submitted_at,
                UserId = model.UserId
            };
        }
    }
}
