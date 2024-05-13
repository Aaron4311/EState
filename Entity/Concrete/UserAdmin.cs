using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
	public class UserAdmin : IdentityUser,IEntity
	{
		
		public string FullName { get; set;}
		public virtual List<Advert> Adverts { get; set;}
	}
}
