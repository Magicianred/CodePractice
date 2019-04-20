using DAL.EF.Fake.Models;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Fake
{
	public interface IDbContext
	{
		DbSetFake<TodoItemFake> TodoItems { get; }
		int SaveChanges();
	}
}
