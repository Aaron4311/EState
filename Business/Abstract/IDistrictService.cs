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
	public interface IDistrictService 
	{
		IDataResult<List<District>> GetAll();
		IDataResult<List<District>> GetFilteredDistricts(Expression<Func<District,bool>> filter);

		IDataResult<District> Get(int id);
		IResult Add(District district);
		IResult Update(District district);
		IResult Delete(int id);
	}
}
