using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Base
{
	public interface IEntityModel
	{
		long Id { get; set; }
		DateTime CreateDate { get; set; }
		DateTime? UpdateDate { get; set; }
		bool IsDeleted { get; set; }
	}
}
