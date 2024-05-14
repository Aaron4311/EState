using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IAdvertService
	{
		IDataResult<List<Advert>> GetAll();
		IDataResult<Advert> Get(int id);
		IResult Add(Advert advert);
		IResult Update(Advert advert);
		IResult Delete(int id);
	}
}
