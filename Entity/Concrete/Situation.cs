using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
	public class Situation : IEntity
	{
        public int SituationId { get; set; }
		public string SituationName { get; set; }
		public bool Status { get; set; }
		public virtual List<Type> Types { get; set; }
    }
}
