using DAL.EF.Models;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Repositories
{
	public class TodoRepository : ITodoRepository,
		IRepository<ITodoItemModel>, 
		IDisposable
	{
		private DatabaseContext _context;

		public TodoRepository()
		{
			this._context = new DatabaseContext();
		}
		public TodoRepository(DatabaseContext context)
		{
			this._context = context;
		}

		#region IRepository
		public IEnumerable<ITodoItemModel> List
		{
			get {
				return _context.TodoItems;
			}
		}

		public ITodoItemModel Find(long id)
		{
			return _context.TodoItems.Find(id);
		}

		public ITodoItemModel Add(ITodoItemModel itemToAdd)
		{
			var item = new TodoItem
			{
				Name = itemToAdd.Name,
				IsComplete = itemToAdd.IsComplete,
			};
			_context.TodoItems.Add(item);
			_context.SaveChanges();
			return item;
		}

		public List<ITodoItemModel> AddRange(List<ITodoItemModel> itemsToAdd)
		{
			var newItems = new List<TodoItem>();
			foreach (var itemToAdd in itemsToAdd) {
				newItems.Add((TodoItem)itemToAdd);
			}
			var retElements = _context.TodoItems.AddRange(newItems);
			_context.SaveChanges();
			return (List<ITodoItemModel>)retElements;
		}

		public bool DeleteById(long id)
		{
			TodoItem item = _context.TodoItems.Find(id);
			_context.TodoItems.Remove(item);
			_context.SaveChanges();
			return true;
		}

		public bool Delete(ITodoItemModel itemToDelete)
		{
			var item = (TodoItem)itemToDelete;
			_context.TodoItems.Remove(item);
			_context.SaveChanges();
			return true;
		}

		public ITodoItemModel Update(ITodoItemModel itemToUpdate)
		{
			_context.Entry((TodoItem)itemToUpdate).State = EntityState.Modified;

			_context.SaveChanges();

			return itemToUpdate;
		}

		public bool Save()
		{
			_context.SaveChanges();
			return true;
		}
		#endregion
		#region ITodoRepository

		public bool SetCompleted(ITodoItemModel item)
		{
			item.IsComplete = true;
			_context.SaveChanges();
			return true;
		}

		public bool SetCompletedById(long id)
		{
			var item = _context.TodoItems.Find(id);
			if (item != null)
			{
				item.IsComplete = true;
				_context.SaveChanges();
				return true;
			}
			else
				return false;
		}

		public bool SetTodo(ITodoItemModel item)
		{
			item.IsComplete = false;
			_context.SaveChanges();
			return true;
		}

		public bool SetTodoById(long id)
		{
			var item = _context.TodoItems.Find(id);
			if (item != null)
			{
				item.IsComplete = false;
				_context.SaveChanges();
				return true;
			}
			else
				return false;
		}

		public bool SetDeleted(ITodoItemModel item)
		{
			item.IsDeleted = true;
			_context.SaveChanges();
			return true;
		}

		public bool SetDeletedById(long id)
		{
			var item = _context.TodoItems.Find(id);
			if (item != null)
			{
				item.IsDeleted = true;
				_context.SaveChanges();
				return true;
			}
			else
				return false;
		}

		public bool SetActivate(ITodoItemModel item)
		{
			item.IsDeleted = false;
			_context.SaveChanges();
			return true;
		}

		public bool SetActivateById(long id)
		{
			var item = _context.TodoItems.Find(id);
			if (item != null)
			{
				item.IsDeleted = false;
				_context.SaveChanges();
				return true;
			}
			else
				return false;
		}


		#endregion


		#region Dispose
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
		#endregion
	}
}