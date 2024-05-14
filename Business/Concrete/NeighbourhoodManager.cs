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
	public class NeighbourhoodManager : INeighbourhoodService
	{
		private INeighbourhoodDal _neighbourhoodDal;
	
		public NeighbourhoodManager(INeighbourhoodDal neighbourhoodDal)
		{
			_neighbourhoodDal = neighbourhoodDal;
		}

		public IResult Add(Neighbourhood neighbourhood)
		{
			_neighbourhoodDal.Add(neighbourhood);
			return new SuccessResult(Messages.neighbourhoodAdded);
		}

		public IResult Delete(int id)
		{
			var deleted = _neighbourhoodDal.Get(x => x.NeighbourhoodId == id);
			_neighbourhoodDal.Delete(deleted);
			return new SuccessResult(Messages.neighbourhoodDeleted);
		}

		public IDataResult<Neighbourhood> Get(int id)
		{
			return new SuccessDataResult<Neighbourhood>(_neighbourhoodDal.Get(x => x.NeighbourhoodId == id), Messages.neighbourhoodListed);
		}

		public IDataResult<List<Neighbourhood>> GetAll()
		{
			return new SuccessDataResult<List<Neighbourhood>>(_neighbourhoodDal.GetAll(), Messages.neighbourhoodListed);

		}

		public IResult Update(Neighbourhood neighbourhood)
		{
			_neighbourhoodDal.Update(neighbourhood);
			return new SuccessResult(Messages.neighbourhoodUpdated);
		}
	}
}
