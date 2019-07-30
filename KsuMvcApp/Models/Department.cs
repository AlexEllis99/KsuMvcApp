using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KsuMvcApp.Models
{
	public class Department
	{
		public int Id { get; set; }
		public string DepartmentName { get; set; }
		public int Id_responsible { get; set; }

		public Department()
		{

		}

		public Department(int Id, string DepartmentName, int Id_responsible)
		{
			this.Id = Id;
			this.DepartmentName = DepartmentName;
			this.Id_responsible = Id_responsible;
		}
	}
}