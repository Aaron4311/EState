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
	public class UserAdminManager : IUserAdminService
	{
		private IUserAdminDal _userAdminDal;

		public UserAdminManager(IUserAdminDal userAdminDal)
		{
			_userAdminDal = userAdminDal;
		}

		public IResult Add(UserAdmin userAdmin)
		{
			_userAdminDal.Add(userAdmin);
			return new SuccessResult(Messages.userAdminAdded);
		}

		public IResult Delete(string id)
		{
			var deleted = _userAdminDal.Get(x => x.Id.Equals(id));
			_userAdminDal.Delete(deleted);
			return new SuccessResult(Messages.userAdminDeleted);
		}

		public IDataResult<UserAdmin> Get(string id)
		{
			return new SuccessDataResult<UserAdmin>(_userAdminDal.Get(x => x.Id.Equals(id)), Messages.userAdminListed);
		}

		public IDataResult<List<UserAdmin>> GetAll()
		{
			return new SuccessDataResult<List<UserAdmin>>(_userAdminDal.GetAll(), Messages.userAdminListed);

		}

		public IResult Update(UserAdmin userAdmin)
		{
			_userAdminDal.Update(userAdmin);
			return new SuccessResult(Messages.userAdminUpdated);
		}
	}
}
