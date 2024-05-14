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
	public class ImageManager : IImageService
	{
		private IImageDal _imageDal;

		public ImageManager(IImageDal imageDal)
		{
			_imageDal = imageDal;
		}

		public IResult Add(Image image)
		{
			_imageDal.Add(image);
			return new SuccessResult(Messages.imageAdded);
		}

		public IResult Delete(int id)
		{
			var deleted = _imageDal.Get(x => x.AdvertId == id);
			_imageDal.Delete(deleted);
			return new SuccessResult(Messages.imageDeleted);
		}

		public IDataResult<Image> Get(int id)
		{
			return new SuccessDataResult<Image>(_imageDal.Get(x => x.AdvertId == id), Messages.imageListed);
		}

		public IDataResult<List<Image>> GetAll()
		{
			return new SuccessDataResult<List<Image>>(_imageDal.GetAll(), Messages.imageListed);

		}

		public IResult Update(Image image)
		{
			_imageDal.Update(image);
			return new SuccessResult(Messages.imageUpdated);
		}
	}
}
