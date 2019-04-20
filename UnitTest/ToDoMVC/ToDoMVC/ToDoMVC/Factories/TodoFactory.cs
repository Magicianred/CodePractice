using Infrastructure.Interfaces;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoMVC.ViewModels;

namespace ToDoMVC.Factories
{
	public class TodoFactory
	{
		/// <summary>
		/// Convert a TodoItem BL Model in a TodoItemViewModel PL Model
		/// </summary>
		/// <param name="data">TodoItem BL Model</param>
		/// <returns>TodoItemViewModel PL Model</returns>
		public TodoItemViewModel GetTodoItemViewModel(ITodoItemModel data) {
			if (data != null)
			{
				var model = new TodoItemViewModel()
				{
					Id = data.Id,
					Name = data.Name,
					IsComplete = data.IsComplete,
					Color = (data.IsComplete ? "green" : "yellow")
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
		public List<TodoItemViewModel> GetTodoItemViewModels(List<ITodoItemModel> dataList)
		{
			List<TodoItemViewModel> modelList = null;
			if (dataList != null && dataList.Count() > 0)
			{
				modelList = new List<TodoItemViewModel>();
				foreach (var data in dataList)
				{
					if (data != null)
						modelList.Add(this.GetTodoItemViewModel(data));
				}
			}

			return modelList;
		}

		/// <summary>
		/// Convert a TodoItemViewModel PL Model in a TodoItem BL Model
		/// </summary>
		/// <param name="data">TodoItemViewModel PL Model</param>
		/// <returns>TodoItem BL Model</returns>
		public ITodoItemModel GetTodoItem(TodoItemViewModel data)
		{
			if (data != null)
			{
				var model = new TodoItemModel()
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
		/// Convert a list of in TodoItemViewModel PL Modela list of TodoItem BL Model 
		/// </summary>
		/// <param name="dataList">list of TodoItemViewModel PL Model</param>
		/// <returns>list of TodoItem BL Model</returns>
		public List<ITodoItemModel> GetTodoItem(List<TodoItemViewModel> dataList)
		{
			List<ITodoItemModel> modelList = null;
			if (dataList != null && dataList.Count() > 0)
			{
				modelList = new List<ITodoItemModel>();
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