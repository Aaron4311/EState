using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Type = Entity.Concrete.Type;
namespace Business.Abstract
{
	public interface ITypeService
	{
		IDataResult<List<Type>> GetAll();
		IDataResult<List<Type>> GetFilteredTypes(Expression<Func<Type, bool>> filter);

		IDataResult<Type> Get(int id);
		IResult Add(Type type);
		IResult Update(Type type);
		IResult Delete(int id);
	}
}
