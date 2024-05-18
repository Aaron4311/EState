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
	public class DistrictManager : IDistrictService
	{
		private IDistrictDal _districtDal;

		public DistrictManager(IDistrictDal districtDal)
		{
			_districtDal = districtDal;
		}

		[ValidationAspect(typeof(DistrictValidator))]

		public IResult Add(District district)
		{
			_districtDal.Add(district);
			return new SuccessResult(Messages.districtAdded);
		}

		public IResult Delete(int id)
		{
			var deleted = _districtDal.Get(x => x.DistrictId == id);
			_districtDal.Delete(deleted);
			return new SuccessResult(Messages.districtDeleted);
		}

		public IDataResult<District> Get(int id)
		{
			return new SuccessDataResult<District>(_districtDal.Get(x => x.DistrictId == id), Messages.advertListed);
		}

		public IDataResult<List<District>> GetAll()
		{
			return new SuccessDataResult<List<District>>(_districtDal.GetAll(), Messages.districtListed);

		}

		public IDataResult<List<District>> GetFilteredDistricts(Expression<Func<District, bool>> filter)
		{
			return new SuccessDataResult<List<District>>(_districtDal.GetAll(filter), Messages.districtListed);

		}

		[ValidationAspect(typeof(DistrictValidator))]
		public IResult Update(District district)
		{
			_districtDal.Update(district);
			return new SuccessResult(Messages.districtUpdated);
		}
	}
}
