using DAL.EF.Models;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Factories
{
	public class TodoFactory
	{
		/// <summary>
		/// Convert a TodoItem BL Model in a TodoItemViewModel PL Model
		/// </summary>
		/// <param name="data">TodoItem BL Model</param>
		/// <returns>TodoItemViewModel PL Model</returns>
		public TodoItem GetTodoItem(ITodoItemModel data)
		{
			if (data != null)
			{
				var model = new TodoItem()
				{
					Id = data.Id,
					Name = data.Name,
					IsComplete = data.IsComplete,
				};
				return model;
			}
			else
				return null;
		}

		/// <summary>
		/// Convert a list of TodoItem BL Model in a list of TodoItemViewModel PL Model
		/// </summary>
		/// <param name="dataList">list of TodoItem BL Model</param>
		/// <returns>list of TodoItemViewModel PL Model</returns>
		public List<TodoItem> GetTodoItems(List<ITodoItemModel> dataList)
		{
			List<TodoItem> modelList = null;
			if (dataList != null && dataList.Count() > 0)
			{
				modelList = new List<TodoItem>();
				foreach (var data in dataList)
				{
					if (data != null)
						modelList.Add(this.GetTodoItem(data));
				}
			}

			return modelList;
		}
		/// <summary>
		/// Convert a list of TodoItem BL Model in a list of TodoItemViewModel PL Model
		/// </summary>
		/// <param name="dataList">list of TodoItem BL Model</param>
		/// <returns>list of TodoItemViewModel PL Model</returns>
		public List<TodoItem> GetTodoItems(IEnumerable<ITodoItemModel> dataList)
		{
			List<TodoItem> modelList = null;
			if (dataList != null)
			{
				modelList = new List<TodoItem>();
				foreach (var data in dataList)
				{
					if (data != null)
						modelList.Add(this.GetTodoItem(data));
				}
			}

			return modelList;
		}
	}
}
