using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KsuMvcApp.Models
{
	public class Notification
	{
		public int Id { get; set; }
		public int Id_User { get; set; }
		public string Notification_Type { get; set; }
		public int Notification_Query { get; set; }
		public string Notification_Date { get; set; }
		public string Message { get; set; }
		public bool IsChecked { get; set; }
	}
}