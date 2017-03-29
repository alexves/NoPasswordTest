using System.Data.Entity;
using NpDal.Migrations;

namespace NpDal
{
    public class NpContext : DbContext
    {
		public NpContext()
			: base("npConnectionString")
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<NpContext, Configuration>());
		}

        public DbSet<User> Users { get; set; }
    }
}