using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EditPageWithJQueryAjax.ViewModels;
using System.IO;

namespace EditPageWithJQueryAjax.Controllers
{
    public class UserController : BaseController
    {
        private static IList<UserViewModel> users;
        public UserController() {
            if (users == null) {
                users = new List<UserViewModel>();
                var user1 = new UserViewModel();
                user1.Id = Guid.NewGuid();
                user1.FirstName = "David";
                user1.LastName = "Beckham";
                user1.Email = "beckham@gmail.com";
                var user2 = new UserViewModel();
                user2.Id = Guid.NewGuid();
                user2.FirstName = "Eric";
                user2.LastName = "Cantona";
                user2.Email = "cantona@gmail.com";
                users.Add(user1);
                users.Add(user2);
            }
        }
        public ActionResult Index()
        {
            return View(users);
        }
        public ActionResult Details(Guid id)
        {
            UserViewModel viewModel = users.First(x => x.Id == id);
            return View(viewModel);
        }
        public ActionResult Edit(Guid id)
        {
            try
            {
                UserViewModel viewModel = users.First(x => x.Id == id);
                return PartialView("_Edit",viewModel);
            }
            catch
            {
                var updateFailed = new
                {
                    messageError = "An error occured while proccessing request"
                };
                return Json(updateFailed, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Edit(UserViewModel input)
        {
            try
            {
                users.First(x => x.Id == input.Id).FirstName = input.FirstName;
                users.First(x => x.Id == input.Id).LastName = input.LastName;
                users.First(x => x.Id == input.Id).Email = input.Email;

                var viewModel = users.First(x => x.Id == input.Id);
                var updateSucced = new
                {
                    html = RenderPartialViewToString("_Details", viewModel),
                    message = "User details has been updated"
                };
                return Json(updateSucced);
            }
            catch 
            {
                var updateFailed = new
                {
                    messageError = "update item failed"
                };
                return Json(updateFailed);
            }
            
        }

      
    }
}
