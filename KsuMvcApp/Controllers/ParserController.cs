using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace KsuMvcApp.Controllers
{
    public class ParserController : Controller
    {
        public ActionResult FindExpression()
        {
            return View();
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult FindExpression(String expression)
		{
			// Вызов метода из парсера
			return View();
		}
	}
}