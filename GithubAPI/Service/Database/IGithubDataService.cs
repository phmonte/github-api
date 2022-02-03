using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubAPI.Service.Database
{
    public interface IGithubDataService
    {
        Task UpdateDatabase(string [] data);
    }
}
