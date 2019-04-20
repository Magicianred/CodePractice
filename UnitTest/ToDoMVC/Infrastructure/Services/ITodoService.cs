using Infrastructure.Interfaces;
using Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
	public interface ITodoService
	{
		//ITodoService();
		//ITodoService(IUnitOfWork unitOfWork);

		IEnumerable<ITodoItemModel> GetAllItems();

		ITodoItemModel InsertItem(ITodoItemModel itemToAdd);

		ITodoItemModel UpdateItem(ITodoItemModel itemToUpdate);

		bool DeleteItem(ITodoItemModel itemToDelete);

		bool DeleteItemById(long id);

		ITodoItemModel FindById(long id);
	}
}
