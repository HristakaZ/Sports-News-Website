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
            Athletes athlete = new Athletes();
            if (ModelState.IsValid)
            {
                List<Sports> allSports = UnitOfWork.UOW.SportRepository.GetAll();
                Sports currentSport = allSports.Where(x => x.ID == athleteViewModel.Sport).FirstOrDefault();
                athlete.ID = athleteViewModel.ID;
                athlete.Name = athleteViewModel.Name;
                athlete.Sport = currentSport;
                return base.Create(athlete);
            }
            else
            {
                List<Sports> allSports = UnitOfWork.UOW.SportRepository.GetAll();
                SelectList selectListItems = new SelectList(allSports, "ID", "Name");
                ViewData["SportsList"] = selectListItems;
                return View(athlete);
            }
        }
        [HttpGet]
        public new ActionResult Read()
        {
            return base.Read();
        }
        [HttpGet]
        public new ActionResult Update(int id)
        {
            List<Sports> allSports = UnitOfWork.UOW.SportRepository.GetAll();
            SelectList selectListItems = new SelectList(allSports, "ID", "Name");
            ViewData["SportsList"] = selectListItems;
            return base.Update(id);
        }
        [HttpPost]
        public new ActionResult Update(UpdateAthleteViewModel updateAthleteViewModel)
        {
            List<Sports> allSports = UnitOfWork.UOW.SportRepository.GetAll();
            Sports currentSport = allSports.Where(x => x.ID == updateAthleteViewModel.Sport).FirstOrDefault();
            List<Athletes> allAthletes = UnitOfWork.UOW.AthleteRepository.GetAll();
            Athletes currentAthlete = allAthletes.Where(x => x.ID == updateAthleteViewModel.ID).FirstOrDefault();
            SelectList selectListItems = new SelectList(allSports, "ID", "Name");
            ViewData["SportsList"] = selectListItems;
            if (ModelState.IsValid)
            {
                if (updateAthleteViewModel.Sport != null)
                {
                    currentAthlete.Sport = currentSport;
                }
                currentAthlete.ID = updateAthleteViewModel.ID;
                currentAthlete.Name = updateAthleteViewModel.Name;
                return base.Update(currentAthlete);
            }
            return View(currentAthlete);
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