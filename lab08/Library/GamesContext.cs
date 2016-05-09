using System.Data.Entity;

namespace Library
{
    public class GamesContext : DbContext
    {
        public GamesContext() : base("GamesContext")
        {
            Database.SetInitializer<GamesContext>(new GamesInitializer());
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}