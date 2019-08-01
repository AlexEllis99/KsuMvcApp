using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KsuMvcApp.Models
{
	public class UserContext : DbContext
	{
		public UserContext() : base("DefaultConnection") { }

		public DbSet<User> Users { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Query> Queries { get; set; }
		public DbSet<Notification> Notifications { get; set; }
	}

	public class UserInitializer : DropCreateDatabaseAlways<UserContext>
	{
		protected override void Seed(UserContext context)
		{
			// Добавление пользователей
			context.Users.Add(new User(1, "Антон", "Смирнов", "Валерьевич") { Id_department = 1, Position = "Начальник управления информатизации", Password = "qwerty11" });

			// Добавление отделов
			context.Departments.Add(new Department(1, "Управление информатизации", 1));

			// Сохранение в бд
			base.Seed(context);
		}
	}
}