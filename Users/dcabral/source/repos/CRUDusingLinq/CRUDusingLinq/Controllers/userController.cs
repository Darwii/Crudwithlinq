using CRUDusingLinq.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDusingLinq.Controllers
{
    public class userController : Controller
    {
        private IUserRepository _repository;
        

        public userController():this(new userRepository())
        {
                
        }
        public userController(IUserRepository repository)
        {
            _repository = repository;
        }
        

        // GET: user
        public ActionResult Create()
        {
            return View(new userdata());
        }
        [HttpPost]
        public ActionResult Create(userdata user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Insertuser(user);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                
                
             ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                   
                
            }
            return View(user);

        }
    }
}