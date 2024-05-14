using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IUserAdminService
	{
		IDataResult<List<UserAdmin>> GetAll();
		IDataResult<UserAdmin> Get(string id);
		IResult Add(UserAdmin userAdmin);
		IResult Update(UserAdmin userAdmin);
		IResult Delete(string id);
	}
}
