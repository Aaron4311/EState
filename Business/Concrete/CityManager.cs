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

namespace Business.Concrete
{
	public class CityManager : ICityService
	{
		private ICityDal _cityDal;

		public CityManager(ICityDal cityDal)
		{
			_cityDal = cityDal;
		}

		[ValidationAspect(typeof(CityValidator))]
		public IResult Add(City city)
		{
			city.Status = true;
			_cityDal.Add(city);
			return new SuccessResult(Messages.cityAdded);
		}

		public IResult Delete(int id)
		{
			var deleted = _cityDal.Get(x => x.CityId == id);
			deleted.Status = false;
			_cityDal.Update(deleted);
			return new SuccessResult(Messages.cityDeleted);
		}

		public IDataResult<City> Get(int id)
		{
			return new SuccessDataResult<City>(_cityDal.Get(x => x.CityId == id), Messages.cityListed);
		}

		public IDataResult<List<City>> GetAll()
		{
			return new SuccessDataResult<List<City>>(_cityDal.GetAll(), Messages.cityListed);

		}

		public IDataResult<List<City>> GetFilteredCities(Expression<Func<City, bool>> filter)
		{
			return new SuccessDataResult<List<City>>(_cityDal.GetAll(filter), Messages.cityListed);

		}

		[ValidationAspect(typeof(CityValidator))]
		public IResult Update(City city)
		{
			_cityDal.Update(city);
			return new SuccessResult(Messages.cityUpdated);
		}
	}
}
