using DAL.EF.Fake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Fake
{
	public class TodoItemSetFake : DbSetFake<TodoItemFake>
	{
		public override TodoItemFake Find(params object[] keyValues)
		{
			return this.SingleOrDefault(d => d.Id == (long)keyValues.Single());
		}

		public new List<TodoItemFake> AddRange(List<TodoItemFake> itemsToAdd) {
			DbContextFakeExtensionMethods.AddRange(this, itemsToAdd);
			return this.ToList();
		}

		public void RemoveRange(List<TodoItemFake> itemsToRemove)
		{
			DbContextFakeExtensionMethods.AddRange(this, itemsToRemove);
		}
	}
}
