using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GithubAPI.Entities
{
    public class Pull
    {
        [Key]
        public int Id { get; set; }
        public int IdPull { get; set; }
        public string Url { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public int ReviewId { get; set; }
        public User User { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime? Closed_at { get; set; }
        public DateTime? Merged_at { get; set; }
        public string RepoFullName { get; set; }
        public List<Review> Reviews { get; set; }
        public bool ReviewSearched { get; set; }
    }
}
