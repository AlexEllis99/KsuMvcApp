using KsuMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KsuMvcApp.Controllers
{
	public class LoginController : Controller
	{

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(Login model)
		{
			if (ModelState.IsValid)
			{
				User principal = null;
				using (UserContext db = new UserContext())
				{
					principal = db.Users.SingleOrDefault(u => u.Nom + " " + u.Prenom == model.Name && u.Password == model.Password);
				}
				if (principal != null)
				{
					FormsAuthentication.SetAuthCookie(model.Name, true);
					Session["username"] = principal.Prenom + " " + principal.Patronym;
					UserController.CurrentUser = principal;
					return RedirectToAction("PersonalProfile", "User", model.Name);
				}
				else
				{
					ModelState.AddModelError("", "Такого пользователя нет. Проверьте правильность введённых данных.");
				}

			}
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult LogOff()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Index", "Home");
		}
	}
}