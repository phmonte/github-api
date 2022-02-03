using GithubAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubAPI.Context
{
    public static class Seed
    {
        public static Group GroupSeed()
        {
            return new Entities.Group
            {
                Name = "microsoft",
                Repository = new List<Entities.Repository>
                {
                    new Entities.Repository
                    {
                        Name = "vstest",
                        Owner = "microsoft"
                    }
                }
            };
        }
    }
}
