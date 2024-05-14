using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
	public class GeneralSettings : IEntity
	{
		public int GeneralSettingsId { get; set; }
		public string Email { get; set;}
		public string PhoneNumber { get; set;}
		public string Address { get; set;}
		public string ImageName { get; set;}
		public IFormFile Image { get; set;}

	}
}
