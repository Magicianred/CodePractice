using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoMVC.ViewModels
{
	/// <summary>
	/// a Presentation Model TodoList element
	/// </summary>
	public class TodoItemViewModel
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public bool IsComplete { get; set; }
		public string Color { get; set; }
	}
}