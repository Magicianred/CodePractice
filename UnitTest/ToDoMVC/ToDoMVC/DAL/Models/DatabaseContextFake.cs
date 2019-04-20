using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Fake.Models
{
	public class DatabaseContextFake : IDbContext
	{
		public DatabaseContextFake()
		{
			this.TodoItems = new TodoItemSetFake();
		}

		public DbSetFake<TodoItemFake> TodoItems { get; set; }

		// IDbSet<TodoItem> IDbContext.TodoItems => throw new NotImplementedException();

		public int SaveChanges()
		{
			return 0;
		}
		
		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					this.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		internal object Entry(TodoItemFake item)
		{
			throw new NotImplementedException();
		}

		internal void AddRange(TodoItemFake item) {

		}
	}
}
