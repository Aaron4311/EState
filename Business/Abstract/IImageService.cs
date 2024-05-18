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
	public interface IImageService
	{
		IDataResult<List<Image>> GetAll();
		IDataResult<List<Image>> GetFilteredImages(Expression<Func<Image,bool>> filter);
		IDataResult<Image> Get(int id);
		IResult Add(Image image);
		IResult Update(Image image);
		IResult Delete(int id);
	}
}
