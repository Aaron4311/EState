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
	public class SituationManager : ISituationService
	{
		private ISituationDal _situationDal;

		public SituationManager(ISituationDal situationDal)
		{
			_situationDal = situationDal;
		}

		[ValidationAspect(typeof(SituationValidator))]
		public IResult Add(Situation situation)
		{
			_situationDal.Add(situation);
			return new SuccessResult(Messages.situationAdded);
		}

		public IResult Delete(int id)
		{
			var deleted = _situationDal.Get(x => x.SituationId == id);
			_situationDal.Delete(deleted);
			return new SuccessResult(Messages.situationDeleted);
		}

		public IDataResult<Situation> Get(int id)
		{
			return new SuccessDataResult<Situation>(_situationDal.Get(x => x.SituationId == id), Messages.situationListed);
		}

		public IDataResult<List<Situation>> GetAll()
		{
			return new SuccessDataResult<List<Situation>>(_situationDal.GetAll(), Messages.situationListed);

		}

		public IDataResult<List<Situation>> GetAllFilteredSituations(Expression<Func<Situation, bool>> filter)
		{
			return new SuccessDataResult<List<Situation>>(_situationDal.GetAll(filter), Messages.situationListed);

		}

		[ValidationAspect(typeof(SituationValidator))]
		public IResult Update(Situation situation)
		{
			_situationDal.Update(situation);
			return new SuccessResult(Messages.situationUpdated);
		}
	}
}
