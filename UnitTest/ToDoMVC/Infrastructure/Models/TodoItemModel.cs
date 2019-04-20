using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Base;
using Infrastructure.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
	public class TodoItemModel : EntityModel, ITodoItemModel, IEntityModel
	{
		public string Name { get; set; }
		public bool IsComplete { get; set; }

		public bool Validate() {
			bool valid = true;

			if (String.IsNullOrEmpty(this.Name))
				valid = false;

			return valid;
		}
	}
}
