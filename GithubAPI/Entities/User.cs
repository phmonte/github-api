using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GithubAPI.Entities
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Node_id { get; set; }
        public string Avatar_url { get; set; }
        public string Gravatar_id { get; set; }
        public string Url { get; set; }
        public string Html_url { get; set; }

        public List<Pull> Pulls { get; set; }
    }
}
