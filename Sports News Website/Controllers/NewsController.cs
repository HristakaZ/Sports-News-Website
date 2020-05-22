using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repositories;
using DataStructure;
using Sports_News_Website.CustomAttributes;
using Sports_News_Website.DTOs;
using Sports_News_Website.Services;
using Sports_News_Website.ViewModels;
using static System.Net.WebRequestMethods;

namespace Sports_News_Website.Controllers
{
    [CustomAuthentication]
    public class NewsController : BaseController<News>
    {
        public NewsController() : base(UnitOfWork.UOW.NewsRepository)
        {

        }
        [HttpGet]
        [CustomAuthorization]
        public new ActionResult Create()
        {
            return base.Create();
        }
        [HttpPost]
        [CustomAuthorization]
        public ActionResult Create(NewsViewModel newsViewModel)
        {
            if (ModelState.IsValid)
            {
                string fileName = newsViewModel.Photo.FileName; // the photo that is uploaded
                string targetFolder = System.Web.HttpContext.Current.Server.MapPath("~/Photo"); // the folder where the photo needs to go
                string targetPath = Path.Combine(targetFolder, fileName); // the whole path
                newsViewModel.Photo.SaveAs(targetPath); // saving the photo
                News news = new News
                {
                    ID = newsViewModel.ID,
                    Title = newsViewModel.Title,
                    Content = newsViewModel.Content,
                    Photo = fileName
                };
                List<Users> allUsers = UnitOfWork.UOW.UserRepository.GetAll();
                Users currentUser = allUsers.Where(x => x.ID == SessionDTO.ID).FirstOrDefault();
                news.User = currentUser;
                return base.Create(news);
            }
            else
            {
                return View(newsViewModel);
            }
        }
        [HttpGet]
        public new ActionResult Read()
        {
            return base.Read();
        }
        [HttpGet]
        public new ActionResult Details(int id)
        {
            News currentNews = UnitOfWork.UOW.NewsRepository.GetByID(id);
            var tupleModel = new Tuple<News, List<Comments>>(currentNews,
                currentNews.Comments);
            System.Web.HttpContext.Current.Session["CurrentNewsID"] = currentNews.ID;
            NewsDTO.NewsID = currentNews.ID;
            return View(tupleModel);
        }
        [HttpGet]
        [CustomAuthorization]
        public new ActionResult Update(int id)
        {
            return base.Update(id);
        }
        [HttpPost]
        [CustomAuthorization]
        public new ActionResult Update(NewsViewModel newsViewModel)
        {
            News news = new News();
            List<News> allNews = UnitOfWork.UOW.NewsRepository.GetAll();
            News currentNews = allNews.Where(x => x.ID == newsViewModel.ID).FirstOrDefault();
            if (newsViewModel.Photo == null)
            {
                news.Photo = currentNews.Photo;
            }
            if (newsViewModel.Photo != null)
            {
                //TO DO : MAKE AN INSERT IMAGE SERVICE AND CHECK FOR THE EXTENSIONS (IF THEY ARE NOT IMAGES, ADD AN ERROR)
                string fileName = newsViewModel.Photo.FileName; // the photo that is uploaded
                string targetFolder = System.Web.HttpContext.Current.Server.MapPath("~/Photo"); // the folder where the photo needs to go
                string targetPath = Path.Combine(targetFolder, fileName); // the whole path
                newsViewModel.Photo.SaveAs(targetPath); // saving the photo
                news.Photo = fileName;
            }
            if (ModelState.IsValid)
            {
                news.ID = newsViewModel.ID;
                news.Title = newsViewModel.Title;
                news.Content = newsViewModel.Content;
                return base.Update(news);
            }
            else
            {
                return View(news);
            }
        }
        [HttpGet]
        [CustomAuthorization]
        public new ActionResult Delete(int? id)
        {
            return base.Delete(id);
        }
        [HttpPost]
        [CustomAuthorization]
        public new ActionResult Delete(int id)
        {
            return base.Delete(id);
        }
    }
}