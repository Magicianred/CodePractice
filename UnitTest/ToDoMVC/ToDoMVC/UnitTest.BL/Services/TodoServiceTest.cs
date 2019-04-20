using BL.Services;
using DAL.EF.Fake.Models;
using DAL.EF.Fake.Repositories;
using Infrastructure.Models;
using Infrastructure.Repositories.Base;
using Infrastructure.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.BL.Services
{
	[TestFixture]
	public class TodoServiceTest
	{
		private DatabaseContextFake _contextFake;
		private IUnitOfWork _unitOfWork;
		private ITodoService _todoService;

		/// <summary>
		/// Run for all each test. Reset and instance new context with tree elements
		/// </summary>
		[SetUp]
		public void setup()
		{
			_contextFake = new DatabaseContextFake
			{
				TodoItems =
					{
					    new TodoItemFake { Id = 1, Name = "BBB"},
					    new TodoItemFake { Id = 2, Name = "AAA"},
					    new TodoItemFake { Id = 3, Name = "ZZZ"},
					}
			};
			_unitOfWork = new UnitOfWorkFake(_contextFake);
			_todoService = new TodoService(_unitOfWork);
		}

		/// <summary>
		/// Test if there are three items with the right name
		/// </summary>
		[Test]
		public void should_order_items_by_id()
		{
			// ARRANGE
			#region Arrange

			#endregion

			// ACT
			#region Act
			var result = _todoService.GetAllItems();
			//// TO FIX : must return IEnumerable
			//Assert.IsInstanceOf<List<TodoItemModel>>(result);

			// ordino gli elementi per id
			result = result.OrderBy(x => x.Id);
			#endregion

			// ASSERT
			#region Assert
			Assert.AreEqual("BBB", result.ElementAt(0).Name);
			Assert.AreEqual("AAA", result.ElementAt(1).Name);
			Assert.AreEqual("ZZZ", result.ElementAt(2).Name);
			#endregion
		}

		/// <summary>
		/// Test if there are three items with the right name
		/// </summary>
		[Test]
		public void should_order_items_by_name()
		{
			// ARRANGE
			#region Arrange

			#endregion

			// ACT
			#region Act
			var result = _todoService.GetAllItems();
			//// TO FIX : must return IEnumerable
			//Assert.IsInstanceOf<List<TodoItemModel>>(result);

			// ordino gli elementi per id
			result = result.OrderBy(x => x.Name);
			#endregion

			// ASSERT
			#region Assert
			Assert.AreEqual("AAA", result.ElementAt(0).Name);
			Assert.AreEqual("BBB", result.ElementAt(1).Name);
			Assert.AreEqual("ZZZ", result.ElementAt(2).Name);
			#endregion
		}

		/// <summary>
		/// Test if there are three items with the right name
		/// </summary>
		[Test]
		public void should_order_items_by_name_after_add_new_item()
		{
			// ARRANGE
			#region Arrange

			#endregion

			// ARRANGE
			#region Arrange

			#endregion

			// ACT
			#region Act
			_todoService.InsertItem(new TodoItemFake()
			{
				Id = 4,
				Name = "CCC"
			});

			var result = _todoService.GetAllItems().ToList();
			//// TO FIX : must return IEnumerable
			//Assert.IsInstanceOf<List<TodoItemModel>>(result);

			// ordino gli elementi per id
			result = result.OrderBy(x => x.Name).ToList();
			#endregion

			// ASSERT
			#region Assert
			Assert.AreEqual("AAA", result.ElementAt(0).Name);
			Assert.AreEqual("BBB", result.ElementAt(1).Name);
			Assert.AreEqual("CCC", result.ElementAt(2).Name);
			Assert.AreEqual("ZZZ", result.ElementAt(3).Name);
			#endregion
		}



		[Test]
		public void should_find_item_by_id()
		{
			// ARRANGE
			#region Arrange

			#endregion

			// ACT
			#region Act
			var itemToFind = _todoService.FindById(1);
			#endregion

			// ASSERT
			#region Assert
			Assert.IsNotNull(itemToFind);
			// To DO implement equal comparator
			// Assert.AreSame(new TodoItemFake { Id = 1, Name = "BBB" }, itemToFind);
			Assert.AreEqual(1, itemToFind.Id);
			Assert.AreEqual("BBB", itemToFind.Name);
			#endregion
		}

		[Test]
		public void should_not_find_item_by_id()
		{
			// ARRANGE
			#region Arrange

			#endregion

			// ACT
			#region Act
			var itemToFind = _todoService.FindById(10);
			#endregion

			// ASSERT
			#region Assert
			Assert.IsNull(itemToFind);
			#endregion
		}

		[Test]
		public void should_update_item()
		{
			// ARRANGE
			#region Arrange
			var itemToUpdate = _todoService.FindById(1);
			var now = DateTime.Now;
			#endregion

			// ACT
			#region Act
			itemToUpdate.Name = "Task completato";
			itemToUpdate.IsComplete = true;
			itemToUpdate.UpdateDate = now;
			var itemToUpdateReturned = _todoService.UpdateItem(itemToUpdate);
			#endregion

			// ASSERT
			#region Assert
			Assert.IsNotNull(itemToUpdateReturned);
			Assert.AreEqual("Task completato", itemToUpdateReturned.Name);
			Assert.AreEqual(true, itemToUpdateReturned.IsComplete);
			Assert.AreEqual(now, itemToUpdateReturned.UpdateDate);
			#endregion
		}

		[Test]
		public void should_create_item()
		{
			// ARRANGE
			#region Arrange
			var newItem = new TodoItemFake() { Id = 21, Name = "Create Item", IsComplete = true };
			#endregion

			// ACT
			#region Act
			var itemInserted = _todoService.InsertItem(newItem);
			#endregion

			// ASSERT
			#region Assert
			Assert.IsNotNull(itemInserted);
			Assert.AreEqual("Create Item", itemInserted.Name);
			Assert.AreEqual(true, itemInserted.IsComplete);
			Assert.IsNull(itemInserted.UpdateDate);
			#endregion
		}

		[Test]
		public void should_delete_item_by_id()
		{
			// ARRANGE
			#region Arrange

			#endregion

			// ACT
			#region Act
			var itemToRemove = _todoService.FindById(1);
			var resultAction = _todoService.DeleteItemById(1);
			var itemRemoved = _todoService.FindById(1);
			#endregion

			// ASSERT
			#region Assert
			Assert.IsNotNull(itemToRemove);
			Assert.IsTrue(resultAction);
			Assert.IsNull(itemRemoved);
			#endregion
		}

		[Test]
		public void should_delete_item()
		{
			// ARRANGE
			#region Arrange
			var itemToRemove = _todoService.FindById(1);
			#endregion

			// ACT
			#region Act
			var resultAction = _todoService.DeleteItem(itemToRemove);
			var itemRemoved = _todoService.FindById(1);
			#endregion

			// ASSERT
			#region Assert
			Assert.IsNotNull(itemToRemove);
			Assert.IsTrue(resultAction);
			Assert.IsNull(itemRemoved);
			#endregion
		}
	}
}
