using AutoMapper;
using SchoolManager.BLL.CrossLevelEntities;
using SchoolManager.BLL.Interfaces;
using SchoolManager.PL.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SchoolManager.PL.Controllers
{
    public class HomeController : Controller
    {
        IPersonService personService;
        public HomeController(IPersonService iPersonService)
        {
            personService = iPersonService;
        }
        public ActionResult Index()
        {
            List<PersonCLE> personD = personService.GetPersons();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PersonCLE, PersonViewModel>()).CreateMapper();
            var persons = mapper.Map<List<PersonCLE>, List<PersonViewModel>>(personD);
            return View(persons);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(PersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PersonViewModel, PersonCLE>()).CreateMapper();
                try
                {
                    personService.Create(mapper.Map<PersonViewModel, PersonCLE>(person));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(person);
                }
                return RedirectToAction("Index", "Home");
            }
            return View(person);
        }
        protected override void Dispose(bool disposing)
        {
            personService.Dispose();
            base.Dispose(disposing);
        }
    }
}