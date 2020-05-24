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
        public new ActionResult Update(AthleteViewModel athleteViewModel)
        {
            Athletes athlete = new Athletes();
            List<Sports> allSports = UnitOfWork.UOW.SportRepository.GetAll();
            Sports currentSport = allSports.Where(x => x.ID == athleteViewModel.Sport).FirstOrDefault();
            List<Athletes> allAthletes = UnitOfWork.UOW.AthleteRepository.GetAll();
            Athletes currentAthlete = allAthletes.Where(x => x.ID == athleteViewModel.ID).FirstOrDefault();
            if (!ModelState.IsValid)
            {
                SelectList selectListItems = new SelectList(allSports, "ID", "Name");
                ViewData["SportsList"] = selectListItems;
                return View(currentAthlete);
            }
            if (athleteViewModel.Sport == 0)
            {
                athlete.ID = athleteViewModel.ID;
                athlete.Name = athleteViewModel.Name;
                athlete.Sport = currentAthlete.Sport;
                return base.Update(athlete);
            }
            if (athleteViewModel.Sport != 0)
            {
                athlete.ID = athleteViewModel.ID;
                athlete.Name = athleteViewModel.Name;
                athlete.Sport = currentSport;
                return base.Update(athlete);
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