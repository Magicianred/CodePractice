using DAL.EF.Fake.Models;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://www.programmingwithwolfgang.com/repository-and-unit-of-work-pattern/
/// </summary>
namespace DAL.EF.Fake.Repositories
{
	public class UnitOfWorkFake : IUnitOfWork
	{
		private DatabaseContextFake _context;

		public UnitOfWorkFake()
		{
			_context = new DatabaseContextFake();
			TodoRepository = new TodoRepositoryFake(_context);
		}
		public UnitOfWorkFake(DatabaseContextFake context)
		{
			_context = context;
			TodoRepository = new TodoRepositoryFake(_context);
		}

		public ITodoRepository TodoRepository { get; }

		public int Complete()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
