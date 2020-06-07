using BugTracker.Data.Models;
using BugTracker.Data.Utils;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OperatingSystem = BugTracker.Data.Models.OperatingSystem;
using Version = BugTracker.Data.Models.Version;

namespace BugTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly int MAX_RECORDS = 50;

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Version> Versions { get; set; }

        public virtual DbSet<ProductOSVersion> ProductOSVersions { get; set; }

        public virtual DbSet<OperatingSystem> OperatingSystems { get; set; }

        public virtual DbSet<IssueStatus> IssueStatusList { get; set; }

        public virtual DbSet<Issue> Issues { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public ApplicationDbContext() { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProductOSVersion>()
                .HasAlternateKey(x => new { x.ProductId, x.OperatingSystemId, x.VersionId });

            //Seed Data
            builder.Entity<Product>().HasData(FakeDataUtils.GetFakeProducts());
            builder.Entity<Version>().HasData(FakeDataUtils.GetFakeVersions());

            builder.Entity<OperatingSystem>().HasData(FakeDataUtils.GetFakeOperatingSystems());
            builder.Entity<IssueStatus>().HasData(FakeDataUtils.GetFakeIssueStatusList());
            var rangeConfig = new RangeConfigProductOSVersion()
            {
                MinProductId = 1,
                MaxProductId = FakeDataUtils.GetCountOfProductsList(),
                MinOperatingSystemId = 1,
                MaxOperatingSystemId = FakeDataUtils.GetCountOfOperatingSystem(),
                MinVersionId = 1,
                MaxVersionId = FakeDataUtils.GetCountOfVersionsList()
            };
            builder.Entity<ProductOSVersion>().HasData(FakeDataUtils.GetFakeProductOsVersions(MAX_RECORDS, rangeConfig));
            var rangeConfigIssue = new RangeConfigIssue()
            {
                MinIssueStatusId = 1,
                MaxIssueStatusId = FakeDataUtils.GetCountOfIssueStatusList(),
                MinProductOSVersionId = 1,
                MaxProductOSVersionId = MAX_RECORDS
            };
            builder.Entity<Issue>().HasData(FakeDataUtils.GetFakeIssues(MAX_RECORDS, rangeConfigIssue));
        }
    }
}
