using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Runtime.Serialization;
using Core.Common.Contracts;
using HN.Pim.Business.Entities;

namespace HN.Pim.Data
{
    public class PimContext : DbContext
    {
        public PimContext()
            : base("name=HN-Pim-Dev")
        {
            Database.SetInitializer<PimContext>(null);
        }

        public DbSet<Product> ProductSet { get; set; }
        public DbSet<ResourceMaster> ResourceMasterSet { get; set; }
        public DbSet<CultureCountryCode> CultureCountryCodeSet { get; set; }
        public DbSet<Account> AccountSet { get; set; }

        public DbSet<Style> StyleSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Ignore<PropertyChangedEventHandler>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            modelBuilder.Entity<Style>().HasKey<int>(e => e.MerretStyleID).Ignore(e => e.EntityId);
            modelBuilder.Entity<Product>().HasKey<int>(e => e.AccountId).Ignore(e => e.EntityId);
            modelBuilder.Entity<ResourceMaster>().HasKey<int>(e => e.ResourceId).Ignore(e => e.EntityId);
            modelBuilder.Entity<CultureCountryCode>().HasKey<int>(e => e.Id).Ignore(e => e.EntityId);
            modelBuilder.Entity<Account>().HasKey<int>(e => e.AccountId).Ignore(e => e.EntityId);
        }
    }
}