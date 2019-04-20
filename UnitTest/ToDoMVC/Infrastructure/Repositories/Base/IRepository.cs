using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://medium.com/falafel-software/implement-step-by-step-generic-repository-pattern-in-c-3422b6da43fd
/// </summary>
namespace Infrastructure.Repositories.Base
{
	public interface IRepository<T> where T : IEntityModel
	{
		IEnumerable<T> List { get; }
		T Add(T entity);
		List<T> AddRange(List<T> entities);
		bool Delete(T entity);
		bool DeleteById(long id);
		T Update(T entity);
		T Find(long id);
		bool Save();
	}
}
