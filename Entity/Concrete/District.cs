using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
	public class District
	{
		public int DistrictId { get; set; }
		public string DistrictName { get; set; }
		public bool Status { get; set; }
		public int CityId { get; set; }
		public virtual City City { get; set; }
		public virtual List<District> Districts { get; set; }
	}
}
