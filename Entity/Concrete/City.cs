﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
	public class City : IEntity
	{
		
		public int CityId { get; set; }
		public string CityName { get; set; }	
		public bool Status { get; set; }
		public virtual List<District> Districts { get; set; }
	}
}
