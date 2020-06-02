using Bogus;
using BugTracker.Data.Models;
using System;
using System.Collections.Generic;
using OperatingSystem = BugTracker.Data.Models.OperatingSystem;
using Version = BugTracker.Data.Models.Version;

namespace BugTracker.Data.Utils
{
    public static class FakeDataUtils
    {
        private static readonly  OperatingSystem[] _operatingSystemList = new List<OperatingSystem>()
        {
            new OperatingSystem()
            { Id = 1, OSName = "Windows" },
            new OperatingSystem()
            { Id = 2, OSName = "Linux" },
            new OperatingSystem()
            { Id = 3, OSName = "MacOS" },
            new OperatingSystem()
            { Id = 4, OSName = "Android" },
            new OperatingSystem()
            { Id = 5, OSName = "iOS" },
            new OperatingSystem()
            { Id = 6, OSName = "Windows Mobile" }
        }.ToArray();


        private static readonly IssueStatus[] _issueStatusList = new List<IssueStatus>()
        {
            new IssueStatus()
            { Id = 1, Status = "Created" },
            new IssueStatus()
            { Id = 2, Status = "In Progress" },
            new IssueStatus()
            { Id = 3, Status = "Resolved" },
            new IssueStatus()
            { Id = 4, Status = "Closed" }
        }.ToArray();

        public static int GetCountOfOperatingSystem() => _operatingSystemList.Length;

        public static int GetCountOfIssueStatusList() => _issueStatusList.Length;

        public static Product[] GetFakeProducts(int count)
        {
            var fakeProducts = new List<Product>();
            var faker = new Faker("en"); // default en

            for(int i = 0; i < count; i++)
            {
                var product = new Product() { Id = i + 1, ProductName = faker.Commerce.ProductName() };
                fakeProducts.Add(product);
            }
            return fakeProducts.ToArray();
        }

        public static Version[] GetFakeVersions(int count)
        {
            var fakeVersions = new List<Version>();
            var faker = new Faker("en"); // default en

            for(int i = 0; i < count; i++)
            {
                var version = new Version() { Id = i + 1, VersionName = faker.System.Version().ToString() };
                fakeVersions.Add(version);
            }
            return fakeVersions.ToArray();
        }

        public static OperatingSystem[] GetFakeOperatingSystems() { return _operatingSystemList; }

        public static IssueStatus[] GetFakeIssueStatusList() { return _issueStatusList; }

        public static ProductOSVersion[] GetFakeProductOsVersions(int count, RangeConfigProductOSVersion rangeConfig)
        {
            var fakeProductOsVersions = new List<ProductOSVersion>();
            var faker = new Faker("en"); // default en

            for(int i = 0; i < count; i++)
            {
                var productOsVersion = new ProductOSVersion()
                {
                    Id = i + 1,
                    ProductId = faker.Random.Number(rangeConfig.MinProductId, rangeConfig.MaxProductId),
                    OperatingSystemId =
                    faker.Random.Number(rangeConfig.MinOperatingSystemId, rangeConfig.MaxOperatingSystemId),
                    VersionId = faker.Random.Number(rangeConfig.MinVersionId, rangeConfig.MaxVersionId),
                };
                fakeProductOsVersions.Add(productOsVersion);
            }
            return fakeProductOsVersions.ToArray();
        }

        public static Issue[] GetFakeIssues(int count, RangeConfigIssue rangeConfig)
        {
            var fakeIssues = new List<Issue>();
            var faker = new Faker("en"); // default en

            for(int i = 0; i < count; i++)
            {
                var issueStatusId = faker.Random.Number(rangeConfig.MinIssueStatusId, rangeConfig.MaxIssueStatusId);
                var productOsVersionId = faker.Random
                    .Number(rangeConfig.MinProductOSVersionId, rangeConfig.MaxProductOSVersionId);
                string resolution = string.Empty;
                DateTime? resolutionDate = null;
                DateTime creationDate = faker.Date.Recent();
                if(issueStatusId == 3 || issueStatusId == 4)
                {
                    resolution = faker.Lorem.Paragraph();
                    resolutionDate = faker.Date.Future(2, creationDate);
                }
                var issue = new Issue()
                {
                    Id = i + 1,
                    ProductOSVersionId = productOsVersionId,
                    IssueStatusId = issueStatusId,
                    Description = faker.Lorem.Paragraph(),
                    Resolution = resolution,
                    CreationDate = creationDate,
                    ResolutionDate = resolutionDate
                };
                fakeIssues.Add(issue);
            }
            return fakeIssues.ToArray();
        }
    }
}
