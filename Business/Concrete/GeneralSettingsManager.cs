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
	public class GeneralSettingsManager : IGeneralSettingsService
	{
		private IGeneralSettingsDal _generalSettingsDal;

		public GeneralSettingsManager(IGeneralSettingsDal generalSettingsDal)
		{
			_generalSettingsDal = generalSettingsDal;
		}

		public IResult Add(GeneralSettings generalSettings)
		{
			_generalSettingsDal.Add(generalSettings);
			return new SuccessResult(Messages.generalSettingsAdded);
		}

		public IResult Delete(int id)
		{
			var deleted = _generalSettingsDal.Get(x => x.GeneralSettingsId == id);
			_generalSettingsDal.Delete(deleted);
			return new SuccessResult(Messages.generalSettingsDeleted);
		}

		public IDataResult<GeneralSettings> Get(int id)
		{
			return new SuccessDataResult<GeneralSettings>(_generalSettingsDal.Get(x => x.GeneralSettingsId == id), Messages.generalSettingsListed);
		}

		public IDataResult<List<GeneralSettings>> GetAll()
		{
			return new SuccessDataResult<List<GeneralSettings>>(_generalSettingsDal.GetAll(), Messages.generalSettingsListed);

		}

		public IResult Update(GeneralSettings generalSettings)
		{
			_generalSettingsDal.Update(generalSettings);
			return new SuccessResult(Messages.generalSettingsUpdated);
		}
	}
}
