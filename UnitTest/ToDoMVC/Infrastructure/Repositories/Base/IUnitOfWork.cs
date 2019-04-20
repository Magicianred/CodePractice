using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Base
{
	public interface IUnitOfWork : IDisposable
	{
		ITodoRepository TodoRepository { get; }

		int Complete();
	}
}
