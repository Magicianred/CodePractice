using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Base;
using Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public interface ITodoRepository : 
		IRepository<ITodoItemModel>, 
		IDisposable
	{
		//new IEnumerable<ITodoItem> List { get; }
		//new ITodoItem Add(ITodoItem entity);
		//new List<ITodoItem> AddRange(List<ITodoItem> entities);
		//new bool Delete(ITodoItem entity);
		//new bool DeleteById(int id);
		//new bool Update(ITodoItem entity);
		//new ITodoItem Find(int id);
		//new bool Save();

		bool SetCompleted(ITodoItemModel item);
		bool SetCompletedById(long id);

		bool SetTodo(ITodoItemModel item);
		bool SetTodoById(long id);

		bool SetDeleted(ITodoItemModel item);
		bool SetDeletedById(long id);

		bool SetActivate(ITodoItemModel item);
		bool SetActivateById(long id);
	}
}
