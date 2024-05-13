using Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
	public class EStateContext : IdentityDbContext<UserAdmin>
	{
        public EStateContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Advert> Adverts { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<District> Districts { get; set; }
		public DbSet<GeneralSettings> GeneralSettings { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<Neighbourhood> Neighbourhoods { get; set; }
		public DbSet<Situation>	Situations { get; set; }
		public DbSet<Entity.Concrete.Type> Types { get; set; }
		public DbSet<UserAdmin> UserAdmins { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Advert>().Ignore(x => x.Image);
			
			modelBuilder.Entity<GeneralSettings>().Ignore(x => x.Image);

			modelBuilder.Entity<District>().HasKey(x => x.DistrictId);

			modelBuilder.Entity<UserAdmin>().HasKey(x => x.Id);
			base.OnModelCreating(modelBuilder);

		}


	}
}
