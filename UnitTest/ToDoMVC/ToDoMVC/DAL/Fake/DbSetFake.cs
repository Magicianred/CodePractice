using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://romiller.com/2012/02/14/testing-with-a-fake-dbcontext/
/// </summary>
namespace DAL.EF.Fake
{
	public class DbSetFake<T> : IDbSet<T> where T : class
	{
		ObservableCollection<T> _data;
		IQueryable _query;

		public DbSetFake()
		{
			_data = new ObservableCollection<T>();
			_query = _data.AsQueryable();
		}

		public virtual T Find(params object[] keyValues)
		{
			// throw new NotImplementedException("Derive from FakeDbSet<T> and override Find");
			//var id = (long)keyValues.Single();
			//return this.SingleOrDefault(b => b.Id == id);

			ParameterExpression _ParamExp = Expression.Parameter(typeof(T), "a");

			Expression _BodyExp = null;

			Expression _Prop = null;
			Expression _Cons = null;

			PropertyInfo[] props = typeof(T).GetProperties();
			var typeName = typeof(T).Name.ToLower() + "id";
			var key = props.Where(p => (p.Name.ToLower().Equals("id")) || (p.Name.ToLower().Equals(typeName))).Single();


			_Prop = Expression.Property(_ParamExp, key.Name);
			_Cons = Expression.Constant(keyValues.Single(), key.PropertyType);

			_BodyExp = Expression.Equal(_Prop, _Cons);

			var _Lamba = Expression.Lambda<Func<T, Boolean>>(_BodyExp, new ParameterExpression[] { _ParamExp });

			return this.SingleOrDefault(_Lamba);
		}

		public T Add(T item)
		{
			_data.Add(item);
			return item;
		}

		public IEnumerable<T> AddRange(List<T> items)
		{
			foreach(var item in items)
				_data.Add(item);
			return items;
		}

		public T Remove(T item)
		{
			_data.Remove(item);
			return item;
		}

		public void RemoveRange(IList<T> items)
		{
			foreach (var item in items)
				_data.Remove(item);
		}

		public T Attach(T item)
		{
			_data.Add(item);
			return item;
		}

		public T Detach(T item)
		{
			_data.Remove(item);
			return item;
		}

		public T Create()
		{
			return Activator.CreateInstance<T>();
		}

		public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
		{
			return Activator.CreateInstance<TDerivedEntity>();
		}

		public ObservableCollection<T> Local
		{
			get { return _data; }
		}

		Type IQueryable.ElementType
		{
			get { return _query.ElementType; }
		}

		System.Linq.Expressions.Expression IQueryable.Expression
		{
			get { return _query.Expression; }
		}

		IQueryProvider IQueryable.Provider
		{
			get { return _query.Provider; }
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return _data.GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return _data.GetEnumerator();
		}
	}
}
