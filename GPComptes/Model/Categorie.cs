using System.Collections.Generic;

namespace GPComptes.Model
{
	public class Categorie : EntiteBase
	{
		public string Libelle { get; set; }

		public virtual ICollection<Operation> Operations { get; set; }
	}
}
