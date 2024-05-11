using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace languages.Models
{
	public class Entities:IdentityDbContext<ApplicationUser>
	{
		public Entities() : base()
		{

		}
		public Entities(DbContextOptions options) : base(options)
		{

		}

		public DbSet<SkinCareProduct> SkinCare{ get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\Local; Initial Catalog=TaskWebsite; Integrated Security=True");
			base.OnConfiguring(optionsBuilder);
		}
	}
}
