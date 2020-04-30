using DataAccess.Repositories;
using DataStructure;
using Sports_News_Website.CustomAttributes;
using Sports_News_Website.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_News_Website.Controllers
{
    [CustomAuthentication]
    public class CommentController : BaseController<Comments>
    {
        public CommentController() : base(UnitOfWork.UOW.CommentRepository)
        {

        }
        [HttpGet]
        public new ActionResult Create()
        {
            return base.Create();
        }
        [HttpPost]
        public new ActionResult Create(Comments comment)
        {
            List<Users> allUsers = UnitOfWork.UOW.UserRepository.GetAll();
            Users currentUser = allUsers.Where(x => x.ID == SessionDTO.ID).FirstOrDefault();
            comment.User = currentUser;
            List<News> allNews = UnitOfWork.UOW.NewsRepository.GetAll();
            News currentNews = allNews.Where(x => x.ID == NewsDTO.NewsID).FirstOrDefault();
            comment.News = currentNews;
            return base.Create(comment);
        }
        [HttpGet]
        public new ActionResult Read()
        {
            return base.Read();
        }
        [HttpGet]
        public new ActionResult Update(int id)
        {
            return base.Update(id);
        }
        [HttpPost]
        public new ActionResult Update(Comments comment)
        {
            return base.Update(comment);
        }
        [HttpGet]
        public new ActionResult Delete(int? id)
        {
            return base.Delete(id);
        }
        [HttpPost]
        public new ActionResult Delete(int id)
        {
            return base.Delete(id);
        }
    }
}