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
	public class AdvertManager : IAdvertService
	{
		private IAdvertDal _advertDal;
		public AdvertManager(IAdvertDal advertDal)
		{
			_advertDal = advertDal;
		}

		[ValidationAspect(typeof(AdvertValidator))]
		public IResult Add(Advert advert)
		{
			advert.Status = true;
			advert.AdvertDate = DateTime.Now;
			_advertDal.Add(advert);
			return new SuccessResult(Messages.advertAdded);
		}

		public IResult Delete(int id)
		{
			var deleted = _advertDal.Get(x => x.AdvertId == id);
			deleted.Status = false;
			_advertDal.Delete(deleted);
			return new SuccessResult(Messages.advertDeleted);
		}

		public IResult FullDelete(int id)
		{
			var advert = _advertDal.Get(x => x.AdvertId == id);
			_advertDal.Delete(advert);
			return new SuccessResult(Messages.advertDeleted);

		}

		public IDataResult<Advert> Get(int id)
		{
			return new SuccessDataResult<Advert>(_advertDal.Get(x => x.AdvertId == id), Messages.advertListed);
		}

		public IDataResult<List<Advert>> GetAll()
		{
			return new SuccessDataResult<List<Advert>>(_advertDal.GetAll(), Messages.advertListed);

		}


		public IDataResult<List<Advert>> GetFilteredAdverts(Expression<Func<Advert, bool>> filter)
		{
			return new SuccessDataResult<List<Advert>>(_advertDal.GetAll(filter), Messages.advertListed);

		}

		public IResult RestoreDeleted(int id)
		{
			var deleted = _advertDal.Get(x => x.AdvertId == id);
			deleted.Status = true;
			_advertDal.Update(deleted);
			return new SuccessResult(Messages.advertRestored);
		}

		[ValidationAspect(typeof(AdvertValidator))]
		public IResult Update(Advert advert)
		{
			_advertDal.Update(advert);
			return new SuccessResult(Messages.advertUpdated);
		}
	}
}
