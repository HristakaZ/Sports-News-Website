using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sports_News_Website.DTOs
{
    public class NewsDTO
    {
        public static int NewsID
        {
            get
            {
                return System.Web.HttpContext.Current.Session["NewsID"] == null ? 0 : (int)System.Web.HttpContext.Current.Session["NewsID"];
            }
            set
            {
                System.Web.HttpContext.Current.Session["NewsID"] = value;
            }
        }
        private NewsDTO()
        {

        }
    }
}