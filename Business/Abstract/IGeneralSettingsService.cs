using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IGeneralSettingsService
	{
		IDataResult<List<GeneralSettings>> GetAll();
		IDataResult<GeneralSettings> Get(int id);
		IResult Add(GeneralSettings generalSettings);
		IResult Update(GeneralSettings generalSettings);
		IResult Delete(int id);
	}
}
