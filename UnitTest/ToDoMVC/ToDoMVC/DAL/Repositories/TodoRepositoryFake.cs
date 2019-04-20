using DAL.EF.Fake.Models;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Base;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Fake.Repositories
{
	public class TodoRepositoryFake : ITodoRepository, IRepository<ITodoItemModel>, IDisposable
	{
		private DatabaseContextFake _context;

		public TodoRepositoryFake()
		{
			this._context = new DatabaseContextFake();
		}
		public TodoRepositoryFake(DatabaseContextFake context)
		{
			this._context = context;
		}

		#region IRepository
		public IEnumerable<ITodoItemModel> List
		{
			get {
				return _context.TodoItems.ToList();
			}
		}

		public ITodoItemModel Find(long id)
		{
			return _context.TodoItems.Find(id);
		}

		public ITodoItemModel Add(ITodoItemModel itemToAdd)
		{
			var item = (TodoItemFake)itemToAdd;
			_context.TodoItems.Add(item);
			return item;
		}

		public List<ITodoItemModel> AddRange(List<ITodoItemModel> itemsToAdd)
		{
			var newItems = new List<TodoItemFake>();
			foreach (var itemToAdd in itemsToAdd)
			{
				newItems.Add((TodoItemFake)itemToAdd);
			}
			return (List<ITodoItemModel>)_context.TodoItems.AddRange(newItems);
		}

		public bool DeleteById(long id)
		{
			TodoItemFake item = _context.TodoItems.Find(id);
			_context.TodoItems.Remove(item);
			return true;
		}

		public bool Delete(ITodoItemModel itemToDelete)
		{
			var item = (TodoItemFake)itemToDelete;
			_context.TodoItems.Remove(item);
			return true;
		}

		public ITodoItemModel Update(ITodoItemModel itemToUpdate)
		{
			// itemToUpdate contains new data, so delete previous and add new
			var item = (TodoItemFake)itemToUpdate;
			var oldItemToRemove = _context.TodoItems.Find(item.Id);
			_context.TodoItems.Remove(oldItemToRemove);
			_context.TodoItems.Add(item);

			return item;
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
			try
			{
				item.IsComplete = true;
				_context.SaveChanges();
				return true;
			} catch {
				return false;
			}
		}

		public bool SetCompletedById(long id)
		{
			var item = _context.TodoItems.Find(id);
			if (item != null)
			{
				try
				{
					item.IsComplete = true;
					_context.SaveChanges();
					return true;
				}
				catch
				{
					return false;
				}
			}
			else
				return false;
		}

		public bool SetTodo(ITodoItemModel item)
		{
			try
			{
				item.IsComplete = false;
				_context.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool SetTodoById(long id)
		{
			var item = _context.TodoItems.Find(id);
			if (item != null)
			{
				try
				{
					item.IsComplete = false;
					_context.SaveChanges();
					return true;
				}
				catch
				{
					return false;
				}
			}
			else
				return false;
		}

		public bool SetDeleted(ITodoItemModel item)
		{
			try
			{
				item.IsDeleted = true;
				_context.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool SetDeletedById(long id)
		{
			var item = _context.TodoItems.Find(id);
			if (item != null)
			{
				try
				{
					item.IsDeleted = true;
					_context.SaveChanges();
					return true;
				}
				catch
				{
					return false;
				}
			}
			else
				return false;
		}

		public bool SetActivate(ITodoItemModel item)
		{
			try
			{
				item.IsDeleted = false;
				_context.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool SetActivateById(long id)
		{
			var item = _context.TodoItems.Find(id);
			if (item != null)
			{
				try
				{
					item.IsDeleted = false;
					_context.SaveChanges();
					return true;
				}
				catch
				{
					return false;
				}
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