using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubAPI.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Repository> Repository { get; set; }
    }
}
