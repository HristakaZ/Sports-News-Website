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
            if (ModelState.IsValid)
            {
                List<Users> allUsers = UnitOfWork.UOW.UserRepository.GetAll();
                Users currentUser = allUsers.Where(x => x.ID == SessionDTO.ID).FirstOrDefault();
                comment.User = currentUser;
                List<News> allNews = UnitOfWork.UOW.NewsRepository.GetAll();
                News currentNews = allNews.Where(x => x.ID == NewsDTO.NewsID).FirstOrDefault();
                comment.News = currentNews;
                UnitOfWork.UOW.CommentRepository.Create(comment);
                UnitOfWork.UOW.Save();
                return RedirectToAction("Details", "News", currentNews);
            }
            else
            {
                List<News> allNews = UnitOfWork.UOW.NewsRepository.GetAll();
                News currentNews = allNews.Where(x => x.ID == NewsDTO.NewsID).FirstOrDefault();
                var tupleModel = new Tuple<News, List<Comments>>(currentNews,
                currentNews.Comments);
                return View("~/Views/News/Details.cshtml", tupleModel);
            }
        }
        [HttpGet]
        public new ActionResult Update(int id)
        {
            List<Comments> allComments = UnitOfWork.UOW.CommentRepository.GetAll();
            Comments currentComment = allComments.Where(x => x.ID == id).FirstOrDefault();
            List<Users> allUsers = UnitOfWork.UOW.UserRepository.GetAll();
            Users currentUser = allUsers.Where(x => x.ID == currentComment.User.ID).FirstOrDefault();
            if (currentUser.ID != SessionDTO.ID && SessionDTO.IsAdmin == false)
            {
                return new ViewResult { ViewName = "InsufficientPermission" };
            }
            else
            {
                return base.Update(id);
            }
        }
        [HttpPost]
        public new ActionResult Update(Comments comment)
        {
            if (ModelState.IsValid)
            {
                List<Comments> allComments = UnitOfWork.UOW.CommentRepository.GetAll();
                Comments currentComment = allComments.Where(x => x.ID == comment.ID).FirstOrDefault();
                List<Users> allUsers = UnitOfWork.UOW.UserRepository.GetAll();
                Users currentUser = allUsers.Where(x => x.ID == currentComment.User.ID).FirstOrDefault();
                if (currentUser.ID != SessionDTO.ID && SessionDTO.IsAdmin == false)
                {
                    return new ViewResult { ViewName = "InsufficientPermission" };
                }
                else
                {
                    List<News> allNews = UnitOfWork.UOW.NewsRepository.GetAll();
                    News currentNews = allNews.Where(x => x.ID == NewsDTO.NewsID).FirstOrDefault();
                    UnitOfWork.UOW.CommentRepository.Update(comment);
                    UnitOfWork.UOW.Save();
                    return RedirectToAction("Details", "News", currentNews);
                }
            }
            else
            {
                List<Comments> allComments = UnitOfWork.UOW.CommentRepository.GetAll();
                Comments currentComment = allComments.Where(x => x.ID == comment.ID).FirstOrDefault();
                List<Users> allUsers = UnitOfWork.UOW.UserRepository.GetAll();
                Users currentUser = allUsers.Where(x => x.ID == currentComment.User.ID).FirstOrDefault();
                comment.News = currentComment.News;
                return View(comment);
            }
        }
        [HttpGet]
        public new ActionResult Delete(int? id)
        {
            List<Comments> allComments = UnitOfWork.UOW.CommentRepository.GetAll();
            Comments currentComment = allComments.Where(x => x.ID == id).FirstOrDefault();
            List<Users> allUsers = UnitOfWork.UOW.UserRepository.GetAll();
            Users currentUser = allUsers.Where(x => x.ID == currentComment.User.ID).FirstOrDefault();
            if (currentUser.ID != SessionDTO.ID && SessionDTO.IsAdmin == false)
            {
                return new ViewResult { ViewName = "InsufficientPermission" };
            }
            else
            {
                return base.Delete(id);
            }
        }
        [HttpPost]
        public new ActionResult Delete(int id)
        {
            List<Comments> allComments = UnitOfWork.UOW.CommentRepository.GetAll();
            Comments currentComment = allComments.Where(x => x.ID == id).FirstOrDefault();
            List<Users> allUsers = UnitOfWork.UOW.UserRepository.GetAll();
            Users currentUser = allUsers.Where(x => x.ID == currentComment.User.ID).FirstOrDefault();
            if (currentUser.ID != SessionDTO.ID && SessionDTO.IsAdmin == false)
            {
                return new ViewResult { ViewName = "InsufficientPermission" };
            }
            else
            {
                List<News> allNews = UnitOfWork.UOW.NewsRepository.GetAll();
                News currentNews = allNews.Where(x => x.ID == NewsDTO.NewsID).FirstOrDefault();
                UnitOfWork.UOW.CommentRepository.Delete(id);
                UnitOfWork.UOW.Save();
                return RedirectToAction("Details", "News", currentNews);
            }
        }
    }
}