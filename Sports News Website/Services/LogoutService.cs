using Sports_News_Website.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sports_News_Website.Services
{
    public class LogoutService
    {
        public static void Logout()
        {
            SessionDTO.ID = 0;
            SessionDTO.Username = null;
            SessionDTO.IsAdmin = false;
        }
    }
}