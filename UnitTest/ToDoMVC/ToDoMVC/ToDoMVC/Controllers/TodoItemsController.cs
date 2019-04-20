using BL.Services;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Base;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoMVC.Factories;
using ToDoMVC.ViewModels;

namespace ToDoMVC.Controllers
{
	public class TodoItemsController : Controller
	{
		private ITodoService _service;
		private TodoFactory _todoFac = new TodoFactory();

		public TodoItemsController()
		{
			_service = new TodoService();
		}
		public TodoItemsController(ITodoService service)
		{
			_service = service;
		}

		public ActionResult Index()
		{
			List<TodoItemViewModel> models = null;

			var items = _service.GetAllItems();
			if (items != null && items.Count() > 0)
				models = _todoFac.GetTodoItemViewModels(items.ToList());
			return View(models);
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(TodoItemViewModel viewModel)
		{
			if (viewModel == null)
			{
				ModelState.AddModelError("", "Dati mancanti");
			}

			if (ModelState.IsValid)
			{
				var data = _todoFac.GetTodoItem(viewModel);

				if (_service.InsertItem(data) != null)
				{
					return RedirectToAction("Index");
				}
				else
					ModelState.AddModelError("", "Errore in inserimento");
			}

			return View(viewModel);
		}


		[HttpGet]
		public ActionResult Edit(long id)
		{
			var data = _service.FindById(id);
			var viewModel = _todoFac.GetTodoItemViewModel(data);
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Edit(TodoItemViewModel viewModel)
		{
			if (viewModel == null)
			{
				ModelState.AddModelError("", "Dati mancanti");
			}

			if (ModelState.IsValid)
			{
				var data = _todoFac.GetTodoItem(viewModel);

				if (_service.UpdateItem(data) != null)
				{
					return RedirectToAction("Index");
				}
				else
					ModelState.AddModelError("", "Errore in inserimento");
			}

			return View(viewModel);
		}

		[HttpGet]
		public ActionResult Details(long id)
		{
			var data = _service.FindById(id);
			var viewModel = _todoFac.GetTodoItemViewModel(data);

			return View(viewModel);
		}

		[HttpGet]
		public ActionResult Delete()
		{
			return View();
		}


		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirm(long id)
		{
			var data = _service.FindById(id);
			var viewModel = _todoFac.GetTodoItemViewModel(data);
			if (viewModel == null)
			{
				ModelState.AddModelError("", "Dati mancanti");
			}

			if (_service.DeleteItem(data))
			{
				return RedirectToAction("Index");
			}
			else
				ModelState.AddModelError("", "Errore eliminazione");
		

			return View(viewModel);
		}
	}
}