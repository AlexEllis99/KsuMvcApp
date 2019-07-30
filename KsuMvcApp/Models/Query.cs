using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KsuMvcApp.Models
{
	public class Query
	{
		public int Id { get; set; }
		public int Id_User { get; set; }
		public string Query_Type { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public string Created { get; set; }
		public string Settled { get; set; } 
		public bool Status { get; set; }
		// Нужно прикрепить файлы
		//public string Files { get; set; }

		public void Close()
		{
			Settled = DateTime.Now.ToString();
			Status = true;
		}

		public Query()
		{

		}

		public Query(int Id, int Id_User, string Query_Type, string Title)
		{
			this.Id = Id;
			this.Id_User = Id_User;
			this.Query_Type = Query_Type;
			this.Title = Title;
			Created = DateTime.Now.ToString();
		}
	}
}