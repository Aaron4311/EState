using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfAdvertDal : EfEntityRepositoryBase<Advert,EStateContext>, IAdvertDal
	{
        
    }
}
