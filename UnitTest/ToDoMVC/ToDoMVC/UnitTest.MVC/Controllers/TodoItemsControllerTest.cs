using BL.Services;
using DAL.EF.Fake.Models;
using DAL.EF.Fake.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ToDoMVC.Controllers;
using ToDoMVC.ViewModels;

namespace UnitTest.MVC.Controllers
{
	[TestFixture]
	public class TodoItemsControllerTest
	{
		[Test]
		public void should_return_threeItems_ABC()
		{
			// ARRANGE
			#region Arrange
			var contextFake = new DatabaseContextFake()
			{
				TodoItems =
					{
					    new TodoItemFake { Id = 1, Name = "A"},
					    new TodoItemFake { Id = 2, Name = "B"},
					    new TodoItemFake { Id = 3, Name = "C"},
					}
			};
			var unitOfWorkFake = new UnitOfWorkFake(contextFake);
			var serviceFake = new TodoService(unitOfWorkFake);

			var controller = new TodoItemsController(serviceFake);
			#endregion

			// ACT
			#region Act

			var result = controller.Index() as ViewResult;

			var items = (List<TodoItemViewModel>)result.ViewData.Model;

			#endregion

			// ASSERT
			#region Assert

			// verify model returned is a TodoItemViewModel
			Assert.IsInstanceOf<IEnumerable<TodoItemViewModel>>(result.ViewData.Model);

			// verify Names of items
			Assert.AreEqual("A", items.ElementAt(0).Name);
			Assert.AreEqual("B", items.ElementAt(1).Name);
			Assert.AreEqual("C", items.ElementAt(2).Name);
			#endregion
		}
	}
}

