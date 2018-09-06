﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResultManagementSystem.Data;
using ResultManagementSystem.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResultManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly TestContext _context;

        public AdminController(TestContext context)
        {
            _context = context;
        }       

        // GET: /<controller>/
        public IActionResult AdminIndex()
        {
            return View();
        }

        public IActionResult AddActor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveActor([Bind("ActorType")]Actor actor)
        {
            if (ModelState.IsValid)
            {
                using (var db = _context)
                {

                    var test = new Actor
                    {
                        ActorType = actor.ActorType
                    };

                    db.Actor.Add(test);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = "Successfully Added";
            }
            return RedirectToAction("ViewActorDetails");
        }

        public IActionResult ViewActorDetails()
        {
            var test = _context.Actor.ToList();
            ActorList actorModel = new ActorList
            {

                ActorAll = test
            };

            return View(actorModel);
        }
        [HttpPost]
        public IActionResult ViewActorDetails(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var test = _context.Actor.Where(a => a.ActorId == Id).ToList();
            ActorList actorModel = new ActorList
            {
                ActorAll = test
            };

            return View(actorModel);
        }

        public IActionResult AddLoginInformation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveLogin([Bind("Id, Password, ActorId")]Login login)
        {
            using (var db = _context)
            {

                var test = new Login
                {
                    Id = login.Id,
                    Password = login.Password,
                    ActorId = login.ActorId
                };

                db.Login.Add(test);
                db.SaveChanges();
            }

            return RedirectToAction("ViewLoginDetails");
        }

        public IActionResult ViewLoginDetails()
        {
            var test = _context.Login.ToList();
            LoginList loginModel = new LoginList
            {

                LoginAll = test
            };

            return View(loginModel);
        }

        [HttpPost]
        public IActionResult ViewLoginDetails(int? Id)
        {
            var test = _context.Login.Where(a => a.Id == Id).ToList();
            LoginList loginModel = new LoginList
            {

                LoginAll = test
            };

            return View(loginModel);
        }

        public IActionResult UpdateLoginInformation()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult SaveLoginUpdate(int Id, [Bind("Id, Password, ActorId")]Login login)
        {
            using (var db = _context)
            {

                var test = new Login
                {
                    Id = login.Id,
                    Password = login.Password,
                    ActorId = login.ActorId
                };

                db.Login.Update(test);
                db.SaveChanges();
            }

            return RedirectToAction("ViewLoginDetails");
        }

        public IActionResult DeleteLoginInformation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveLoginDelete(int Id, [Bind("Id, Password, ActorId")]Login login)
        {
            using (var db = _context)
            {

                var test = new Login
                {
                    Id = login.Id,
                    Password = login.Password,
                    ActorId = login.ActorId
                };

                db.Login.Remove(test);
                db.SaveChanges();
            }

            return RedirectToAction("ViewLoginDetails");
        }

        public IActionResult UpdateActorInformation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveActorUpdate(int ActorId, [Bind("ActorId, ActorType")]Actor actor)
        {
            using (var db = _context)
            {

                var test = new Actor
                {
                    ActorId = actor.ActorId,
                    ActorType = actor.ActorType
                };

                db.Actor.Update(test);
                db.SaveChanges();
            }

            return RedirectToAction("ViewActorDetails");
        }

        public IActionResult DeleteActorInformation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveActorDelete(int ActorId, [Bind("ActorId, ActorType")]Actor actor)
        {
            using (var db = _context)
            {

                var test = new Actor
                {
                    ActorId = actor.ActorId,
                    ActorType = actor.ActorType
                };

                db.Actor.Remove(test);
                db.SaveChanges();
            }

            return RedirectToAction("ViewActorDetails");
        }        
    }
}
