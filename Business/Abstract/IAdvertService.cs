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
	public interface IAdvertService
	{
		IDataResult<List<Advert>> GetAll();
		IDataResult<List<Advert>> GetFilteredAdverts(Expression<Func<Advert, bool>> filter);
		IDataResult<Advert> Get(int id);
		IResult Add(Advert advert);
		IResult Update(Advert advert);
		IResult Delete(int id);
		IResult RestoreDeleted(int id);
		IResult FullDelete(int id);
	}
}
