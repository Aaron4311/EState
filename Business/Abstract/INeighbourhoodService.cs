using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface INeighbourhoodService
	{
		IDataResult<List<Neighbourhood>> GetAll();
		IDataResult<List<Neighbourhood>> GetFilteredNeighbourhoods(Expression<Func<Neighbourhood, bool>> filter);

		IDataResult<Neighbourhood> Get(int id);
		IResult Add(Neighbourhood neighbourhood);
		IResult Update(Neighbourhood neighbourhood);
		IResult Delete(int id);
	}
}
