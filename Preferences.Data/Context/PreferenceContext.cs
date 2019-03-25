using System.Data.Entity;
using Preferences.Custom;
using Preferences.Models;

namespace Preferences.Data.Context
{
    public class PreferenceContext : DbContext
    {
        public DbSet<CustomerPreference> Preference { get; set; }

        public PreferenceContext() : base("name=PreferenceConnection") { }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Preferences");

            modelBuilder.Entity<CustomerPreference>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
