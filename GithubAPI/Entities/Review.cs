using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GithubAPI.Entities
{
    public class Review
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int PullId { get; set; }
        public int PullNumber { get; set; }
        public string Body { get; set; }
        public string State { get; set; }
        public string Html_url { get; set; }
        public string Pull_request_url { get; set; }
        public string Author_association { get; set; }
        public Pull Pull { get; set; }
        public DateTime Submitted_at { get; set; }
    }
}
