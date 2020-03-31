using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sports_News_Website.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}