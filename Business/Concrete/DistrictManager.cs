using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public IResult Update(District district)
		{
			_districtDal.Update(district);
			return new SuccessResult(Messages.districtUpdated);
		}
	}
}
