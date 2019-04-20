using Infrastructure.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.Base
{
	public abstract class EntityModel : IEntityModel
	{
		public long Id { get; set; }
		public DateTime CreateDate { get; set; } = DateTime.Now;
		public DateTime? UpdateDate { get; set; }
		public bool IsDeleted { get; set; } = false;
	}
}
