using GPComptes.Model;
using System.Data.Entity;

namespace GPComptes.Dal
{
	public class AppContext : DbContext
	{
		public AppContext() : base("gpcomptes") { }
		
		public DbSet<Operation> Operations { get; set; }
		public DbSet<TypeOperation> Types { get; set; }
		public DbSet<Tiers> Tiers { get; set; }
		public DbSet<Categorie> Categories { get; set; }
		public DbSet<Compte> Comptes { get; set; }
	}
}
