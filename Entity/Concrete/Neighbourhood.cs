using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
	public class Neighbourhood : IEntity
	{
		public int NeighbourhoodId { get; set; }
		public string NeighbourhoodName { get; set; }
		private bool Status { get; set; }
		public int DistrictId { get; set; }
		public virtual District District { get; set; }
	}
}

