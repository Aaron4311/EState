using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
	public class Type : IEntity
	{
		public int TypeId { get; set; }
		public string TypeName { get; set; }
		public bool Status { get; set; }

		public int SituationId { get; set; }
		public virtual Situation Situation { get; set; }
        public virtual List<Advert> Adverts { get; set; }
    }
}
