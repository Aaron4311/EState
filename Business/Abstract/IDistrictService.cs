using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IDistrictService 
	{
		IDataResult<List<District>> GetAll();
		IDataResult<District> Get(int id);
		IResult Add(District district);
		IResult Update(District district);
		IResult Delete(int id);
	}
}
