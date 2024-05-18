using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Type = Entity.Concrete.Type;
namespace Business.Concrete
{
	public class TypeManager : ITypeService
	{
		private ITypeDal _typeDal;

		public TypeManager(ITypeDal typeDal)
		{
			_typeDal = typeDal;
		}

		[ValidationAspect(typeof(TypeValidator))]
		public IResult Add(Type type)
		{
			_typeDal.Add(type);
			return new SuccessResult(Messages.typeAdded);
		}

		public IResult Delete(int id)
		{
			var deleted = _typeDal.Get(x => x.TypeId == id);
			_typeDal.Delete(deleted);
			return new SuccessResult(Messages.typeDeleted);
		}

		public IDataResult<Type> Get(int id)
		{
			return new SuccessDataResult<Type>(_typeDal.Get(x => x.TypeId == id), Messages.typeListed);
		}

		public IDataResult<List<Type>> GetAll()
		{
			return new SuccessDataResult<List<Type>>(_typeDal.GetAll(), Messages.typeListed);

		}

		public IDataResult<List<Type>> GetFilteredTypes(Expression<Func<Type, bool>> filter)
		{
			return new SuccessDataResult<List<Type>>(_typeDal.GetAll(filter), Messages.typeListed);

		}

		[ValidationAspect(typeof(TypeValidator))]
		public IResult Update(Type type)
		{
			_typeDal.Update(type);
			return new SuccessResult(Messages.typeUpdated);
		}
	}
}
