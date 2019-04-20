using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
	public class DatabaseContextInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DatabaseContext>
	{
		protected override void Seed(DatabaseContext context)
		{
			var items = new List<TodoItem>
			    {
			    new TodoItem{Id = 1, Name= "Festeggiare in nuovo anno", IsComplete = true, IsDeleted = true, CreateDate=DateTime.Parse("2018-12-31")},
			    new TodoItem{Id = 2, Name= "Imparare C#", IsComplete = true, IsDeleted = false, CreateDate=DateTime.Parse("2019-01-02")},
			    new TodoItem{Id = 3, Name= "Imparare Entity Framework code first", IsComplete = true, IsDeleted = false, CreateDate=DateTime.Parse("2019-01-15")},
			    new TodoItem{Id = 4, Name= "Esercitarsi con il database SQL Server", IsComplete = false, IsDeleted = false, CreateDate=DateTime.Parse("2019-12-31")},
			    new TodoItem{Id = 5, Name= "Imparare Azure Cosmos DB", IsComplete = false, IsDeleted = true, CreateDate=DateTime.Parse("2019-03-15")},
			    new TodoItem{Id = 6, Name= "Utilizzare Unit Test", IsComplete = false, IsDeleted = false, CreateDate=DateTime.Parse("2019-03-01")},
			    new TodoItem{Id = 7, Name= "Imparare SOLID (code adaptive)", IsComplete = false, IsDeleted = false, CreateDate=DateTime.Parse("2019-04-31")},
			    new TodoItem{Id = 10, Name= "Imparare TDD (Test-driven development)", IsComplete = false, IsDeleted = false, CreateDate=DateTime.Parse("2019-06-31")},
			    new TodoItem{Id = 12, Name= "Imparare BDD (Behavior-Driven Development)", IsComplete = false, IsDeleted = false, CreateDate=DateTime.Parse("2019-08-31")},
			    };
		}
	}
}