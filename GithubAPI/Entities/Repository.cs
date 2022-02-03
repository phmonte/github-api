using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubAPI.Entities
{
    public class Repository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public Group Group { get; set; }
    }
}
