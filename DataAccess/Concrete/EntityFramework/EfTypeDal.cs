using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Entity.Concrete.Type;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfTypeDal : EfEntityRepositoryBase<Type, EStateContext>, ITypeDal
	{
	}
}
