using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KsuMvcApp.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Prenom { get; set; }
		public string Nom { get; set; }
		public string Patronym { get; set; }
		public string Image { get; set; }
		public string FullName { get; set; }
		public string Position { get; set; }
		public string Password { get; set; }
		public int Id_department { get; set; }
		public string department_Name;

		public string Department_Name
		{
			get
			{
				if (department_Name == null)
				{
					using (UserContext db = new UserContext())
					{
						department_Name = db.Departments.SingleOrDefault(d => d.Id == Id_department)?.DepartmentName;
					}
				}
				return department_Name;
				
			}
			set
			{
				department_Name = value;
			}
		}

		public User()
		{
			
		}

		public User(int ID, string Prenom, string Nom)
		{
			this.Prenom = Prenom;
			this.Nom = Nom;
			FullName = Nom + " " + Prenom;
		}
		public User(int ID, string Prenom, string Nom, string Patronym) : this(ID, Prenom, Nom)
		{
			this.Patronym = Patronym;
			FullName = Nom + " " + Prenom + " " + Patronym;
		}
	}
}