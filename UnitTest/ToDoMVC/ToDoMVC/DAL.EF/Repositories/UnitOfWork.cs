using DAL.EF.Models;
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
namespace DAL.EF.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private DatabaseContext _context;
		private ITodoRepository _todoRep;

		public UnitOfWork()
		{
			_context = new DatabaseContext();
			_todoRep = new TodoRepository(_context);
		}
		public UnitOfWork(DatabaseContext context) {
			_context = context;
			_todoRep = new TodoRepository(_context);
		}

		public ITodoRepository TodoRepository { 
			get {
				return (TodoRepository)_todoRep;
			}
		}

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
