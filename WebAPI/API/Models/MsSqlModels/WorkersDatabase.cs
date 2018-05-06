namespace API.Models.MsSqlModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WorkersDatabase : DbContext
    {
        public WorkersDatabase()
            : base("name=WorkersDatabase")
        {
        }

        public virtual DbSet<Workers> Workers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workers>()
                .Property(e => e.Payment)
                .HasPrecision(18, 0);
        }
    }
}
