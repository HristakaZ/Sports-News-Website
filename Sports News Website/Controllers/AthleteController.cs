using DataAccess.Repositories;
using DataStructure;
using Sports_News_Website.CustomAttributes;
using Sports_News_Website.DTOs;
using Sports_News_Website.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_News_Website.Controllers
{
    [CustomAuthentication]
    [CustomAuthorization]
    public class AthleteController : BaseController<Athletes>
    {
        public AthleteController() : base(UnitOfWork.UOW.AthleteRepository)
        {

        }
        [HttpGet]
        public new ActionResult Create()
        {
            List<Sports> allSports = UnitOfWork.UOW.SportRepository.GetAll();
            SelectList selectListItems = new SelectList(allSports, "ID", "Name");
            ViewData["SportsList"] = selectListItems;
            return base.Create();
        }
        [HttpPost]
        public new ActionResult Create(AthleteViewModel athleteViewModel)
        {
            List<Sports> allSports = UnitOfWork.UOW.SportRepository.GetAll();
            Sports currentSport = allSports.Where(x => x.ID == athleteViewModel.Sport).FirstOrDefault();
            Athletes athlete = new Athletes
            {
                ID = athleteViewModel.ID,
                Name = athleteViewModel.Name,
                Sport = currentSport
            };
            return base.Create(athlete);
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
        public new ActionResult Update(Athletes athlete)
        {
            return base.Update(athlete);
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