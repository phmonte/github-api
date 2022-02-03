using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubAPI.DTOs
{
    public class PRUserReview
    {
        public string Login { get; set; }
        public string RepositoryFullName { get; set; }
        public int TotalApprove { get; set; }
    }
}
