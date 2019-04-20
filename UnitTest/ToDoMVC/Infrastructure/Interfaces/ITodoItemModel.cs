using Infrastructure.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
	public interface ITodoItemModel : IEntityModel
	{
		//long Id { get; set; }
		string Name { get; set; }
		bool IsComplete { get; set; }

		bool Validate();
	}
}