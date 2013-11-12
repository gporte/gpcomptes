using System.Collections.Generic;

namespace GPComptes.Model
{
	public class TypeOperation : EntiteBase
	{
		public string Libelle { get; set; }

		public virtual ICollection<Operation> Operations { get; set; }
	}
}
