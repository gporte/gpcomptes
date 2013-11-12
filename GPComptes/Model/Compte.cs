using System;
using System.Collections.Generic;

namespace GPComptes.Model
{
	public class Compte : EntiteBase
	{
		public string Nom { get; set; }
		public DateTime DateCreation { get; set; }

		public virtual ICollection<Operation> Operations { get; set; }
	}
}
