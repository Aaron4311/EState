using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
	public class Image : IEntity
	{
		public int ImageId { get; set; }
        public string ImageName { get; set; }
		public bool Status { get; set; }
		public int	AdvertId { get; set; }
		
    }
}
