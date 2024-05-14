using Core.DataAccess;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Entity.Concrete.Type;

namespace DataAccess.Abstract
{
	public interface ITypeDal : IEntityRepository<Type>
	{
	}
}
