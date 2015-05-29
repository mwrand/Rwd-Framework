using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rwd.Framework
{
    public class User
    {
        public User()
        {
            FullName = string.Empty;
            UserName = string.Empty;
            IsAdmin = false;
            MachineName = string.Empty;
            Groups = new List<string>();
            Title = string.Empty;
        }

        public string FullName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsAdmin { get; set; }
        public string MachineName { get; set; }
        public List<string> Groups { get; set; }
        public string Title { get; set; }
        public Exception UserException { get; set; }
    }
}
