using KsuMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KsuMvcApp.Controllers
{
	[Authorize]
	public class UserController : Controller
	{
		internal static User CurrentUser { get; set; }

		public ActionResult PersonalProfile()
		{
			ViewBag.User = CurrentUser;
			return View();
		}

		public ActionResult Publication()
		{
			ViewBag.UserID = CurrentUser.Id;
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Publication(Query model)
		{
			if (ModelState.IsValid)
			{
				using (UserContext db = new UserContext())
				{
					model.Id = db.Queries.Count() + 1;
					db.Queries.Add(model);

					Notification n = new Notification();
					n.Id = db.Notifications.Count() + 1;
					n.Notification_Date = DateTime.Now.ToString();
					n.Notification_Query = model.Id;
					n.Message = "Запрос на " + model.Query_Type + " " + " №" + model.Id + " был создан.";
					n.Notification_Type = "Отчёт";
					n.Id_User = model.Id_User;
					db.Notifications.Add(n);
					db.SaveChanges();
				}
				return RedirectToAction("PersonalProfile", "User");
			}
			return View(model);
		}

		public ActionResult Notifications()
		{
			using (UserContext db = new UserContext())
			{
				ViewBag.Notifications_List = db.Notifications.Where(n => n.Id_User == CurrentUser.Id).ToList();
			}
			return View();
		}

		public ActionResult Queries()
		{
			using (UserContext db = new UserContext())
			{
				ViewBag.Queries_List = db.Queries.Where(q => q.Id_User == CurrentUser.Id).ToList();
			}
			return View();
		}

		public ActionResult SiteMap()
		{
			
			return View();
		}

		public ActionResult Instructions()
		{
			return View();
		}
	}
}