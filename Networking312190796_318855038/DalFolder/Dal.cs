using Networking312190796_318855038.Models;
using System.Data.Entity;


namespace Networking312190796_318855038.DalFolder
{
    public class Dal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>().ToTable("tblusers");
            modelBuilder.Entity<Movies>().ToTable("tblmovies");
            modelBuilder.Entity<Tickets>().ToTable("tbltickets");
        }
        public DbSet<Users> users { get; set; }
        public DbSet<Movies> movies { get; set; }
        public DbSet<Tickets> tickets { get; set; }
    }
}