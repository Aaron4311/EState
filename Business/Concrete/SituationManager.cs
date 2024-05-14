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
	public class SituationManager
	{
		private ISituationDal _situationDal;

		public SituationManager(ISituationDal situationDal)
		{
			_situationDal = situationDal;
		}

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

		public IResult Update(Situation situation)
		{
			_situationDal.Update(situation);
			return new SuccessResult(Messages.situationUpdated);
		}
	}
}
