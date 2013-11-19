using System;

namespace GPComptes.Model
{
	public enum FlagOperation
	{
		Aucun,
		Pointe
	}
	
	public class Operation : EntiteBase
	{
		public DateTime DateOperation { get; set; }
		public decimal Montant { get; set; }
		public string Description { get; set; }
		public FlagOperation Flag { get; set; }

		public virtual Compte CompteOperation { get; set; }
		public virtual TypeOperation TypeOperation { get; set; }
		public virtual Tiers TiersOperation { get; set; }
		public virtual Categorie CategorieOperation { get; set; }
	}
}
