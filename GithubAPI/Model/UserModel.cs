using GithubAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubAPI.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Node_id { get; set; }
        public string Avatar_url { get; set; }
        public string Gravatar_id { get; set; }
        public string Url { get; set; }
        public string Html_url { get; set; }

        public static explicit operator User(UserModel model)
        {
            return new User
            {
                Id = model.Id,
                Avatar_url = model.Avatar_url,
                Html_url = model.Html_url,
                Gravatar_id = model.Gravatar_id,
                Login = model.Login,
                Node_id = model.Node_id,
                Url = model.Url
            };
        }
    }
}
