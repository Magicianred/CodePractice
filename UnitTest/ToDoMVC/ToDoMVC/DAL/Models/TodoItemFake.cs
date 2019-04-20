using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Fake.Models
{
	public class TodoItemFake : ITodoItemModel
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public bool IsComplete { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime? UpdateDate { get; set; }
		public bool IsDeleted { get; set; }

		public bool Validate() {
			bool isValid = true;

			if (this.Id <= 0)
				isValid = false;

			if (String.IsNullOrEmpty(this.Name))
				isValid = false;

			return isValid;
		}
	}
}
