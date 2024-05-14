using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICityService
    {
        IDataResult<List<City>> GetAll();
        IDataResult<City> Get(int id);
		IResult Add(City city);
		IResult Update(City city);
        IResult Delete(int id);
    }
}
