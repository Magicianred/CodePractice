using DAL.EF.Repositories;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Base;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
	/// <summary>
	/// Service to read Repository data of Todo List elements
	/// </summary>
	public class TodoService : ITodoService
	{
		public IUnitOfWork _unitOfWork;
		public ITodoRepository _todoRep;

		public TodoService()
		{
			_unitOfWork = new UnitOfWork();
			_todoRep = _unitOfWork.TodoRepository;
		}
		public TodoService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_todoRep = _unitOfWork.TodoRepository;
		}

		public bool DeleteItem(ITodoItemModel itemToDelete)
		{
			if (itemToDelete != null)
				return _todoRep.Delete(itemToDelete);
			else
				return false;
		}

		public bool DeleteItemById(long id)
		{
			var itemToDelete = _todoRep.Find(id);
			if (itemToDelete != null)
				return _todoRep.Delete(itemToDelete);
			else
				return false;
		}

		public ITodoItemModel FindById(long id)
		{
			return _todoRep.Find(id);
		}

		public IEnumerable<ITodoItemModel> GetAllItems()
		{
			var results = _todoRep.List;
			return results;
		}

		public ITodoItemModel InsertItem(ITodoItemModel itemToAdd)
		{
			//long newId = 0;
			//if (_todoRep.List != null && _todoRep.List.Count() > 0)
			//	newId = _todoRep.List.Select(x => x.Id).Max();
			//itemToAdd.Id = newId + 1;

			if (itemToAdd.Validate())
			{
				return _todoRep.Add(itemToAdd);
			}

			return null;
		}

		public ITodoItemModel UpdateItem(ITodoItemModel itemToUpdate)
		{
			if (itemToUpdate != null && itemToUpdate.Validate())
			{
				var originalItem = _todoRep.Find(itemToUpdate.Id);

				originalItem.Name = itemToUpdate.Name;
				originalItem.IsComplete = itemToUpdate.IsComplete;

				return _todoRep.Update(originalItem);
			}

			return null;
		}
	}
}
