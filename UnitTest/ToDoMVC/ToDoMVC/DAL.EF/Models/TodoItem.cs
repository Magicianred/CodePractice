using Infrastructure.Interfaces;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
	[Table("TodoItem")]
	public class TodoItem : ITodoItemModel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		[Required(ErrorMessage ="Il nome è richiesto")]
		public string Name { get; set; }

		public bool IsComplete { get; set; } = false;

		public DateTime CreateDate { get; set; } = DateTime.Now;
		public DateTime? UpdateDate { get; set; }

		public bool IsDeleted { get; set; } = false;

		public bool Validate()
		{
			bool isValid = true;

			if (this.Id <= 0)
				isValid = false;

			if (String.IsNullOrEmpty(this.Name))
				isValid = false;

			return isValid;
		}
	}
}
