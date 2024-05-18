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
	public interface ISituationService
	{
		IDataResult<List<Situation>> GetAll();
		IDataResult<List<Situation>> GetAllFilteredSituations(Expression<Func<Situation,bool>> filter);

		IDataResult<Situation> Get(int id);
		IResult Add(Situation situation);
		IResult Update(Situation situation);
		IResult Delete(int id);
	}
}
