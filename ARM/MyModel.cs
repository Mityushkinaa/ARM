namespace ARM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyModel : DbContext
    {
        public MyModel()
            : base("name=OpenModel")
        {
        }

        public virtual DbSet<country> countries { get; set; }
        public virtual DbSet<dacha> dachas { get; set; }
        public virtual DbSet<dacha_owners> dacha_owners { get; set; }
        public virtual DbSet<district> districts { get; set; }
        public virtual DbSet<language> languages { get; set; }
        public virtual DbSet<owner> owners { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<country>()
                .HasMany(e => e.districts)
                .WithRequired(e => e.country)
                .HasForeignKey(e => e.country_id);

            modelBuilder.Entity<dacha>()
                .HasMany(e => e.dacha_owners)
                .WithRequired(e => e.dacha)
                .HasForeignKey(e => e.id_dacha)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<district>()
                .HasMany(e => e.dachas)
                .WithRequired(e => e.district)
                .HasForeignKey(e => e.district_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<language>()
                .HasMany(e => e.countries)
                .WithRequired(e => e.language)
                .HasForeignKey(e => e.lang_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<owner>()
                .HasMany(e => e.dacha_owners)
                .WithRequired(e => e.owner)
                .HasForeignKey(e => e.id_owners)
                .WillCascadeOnDelete(false);
        }
    }
}
