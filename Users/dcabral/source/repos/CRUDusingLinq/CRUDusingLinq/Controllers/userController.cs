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
        public ActionResult Index()
        {
            var users = _repository.GetUserDatas();
            return View(users);
        }
        public ActionResult Details(int id)
        {
            userdata model = _repository.GetuserByID(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            userdata model = _repository.GetuserByID(id);
                return View(model);
        }
        public ActionResult Edit(userdata user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Updateuser(user);
                    return RedirectToAction("Index");
                }
            }
            catch(DataException)
            {
                ModelState.AddModelError("","Unable to save changes please try again");
                
            }
            return View(user);
        }
        public ActionResult Delete(int id,bool? savechangeserror )
        {
            if (savechangeserror.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again";
            }
            userdata user = _repository.GetuserByID(id);
            return View(user);

        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
           
            try
            {
                userdata model = _repository.GetuserByID(id);
                _repository.Deleteuser(id);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new System.Web.Routing.RouteValueDictionary {
          { "id", id },
          { "saveChangesError", true } });

            }
            return RedirectToAction("Index");
        }
    }
}