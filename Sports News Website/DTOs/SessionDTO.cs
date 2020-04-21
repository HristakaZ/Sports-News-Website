using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sports_News_Website.DTOs
{
    public class SessionDTO
    {
        public static int ID { get; set; }
        public static string Username { get; set; }
        public static bool IsAdmin { get; set; }
    }
}