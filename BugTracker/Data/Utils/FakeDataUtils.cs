using Bogus;
using BugTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using OperatingSystem = BugTracker.Data.Models.OperatingSystem;
using Version = BugTracker.Data.Models.Version;

namespace BugTracker.Data.Utils
{
    public static class FakeDataUtils
    {
        private static readonly Product[] _products = new List<Product>()
        {
            new Product()
            { Id = 1, ProductName = "Day Trader Wannabe" },
            new Product()
            { Id = 2, ProductName = "Investment Overlord" },
            new Product()
            { Id = 3, ProductName = "Workout Planner" },
            new Product()
            { Id = 4, ProductName = "Social Anxiety Planner" }
        }.ToArray();

        private static readonly Version[] _versions = new List<Version>()
        {
            new Version()
            { Id = 1, VersionName = "1.0" },
            new Version()
            { Id = 2, VersionName = "1.1" },
            new Version()
            { Id = 3, VersionName = "1.2" },
            new Version()
            { Id = 4, VersionName = "1.3" },
            new Version()
            { Id = 5, VersionName = "2.0" },
            new Version()
            { Id = 6, VersionName = "2.1" },
            new Version()
            { Id = 7, VersionName = "2.2" },
            new Version()
            { Id = 8, VersionName = "2.3" }
        }.ToArray();


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

        public static int GetCountOfProductsList() => _products.Length;

        public static int GetCountOfVersionsList() => _versions.Length;

        public static Product[] GetFakeProducts() { return _products; }

        public static Version[] GetFakeVersions() { return _versions; }

        public static OperatingSystem[] GetFakeOperatingSystems() { return _operatingSystemList; }

        public static IssueStatus[] GetFakeIssueStatusList() { return _issueStatusList; }

        public static ProductOSVersion[] GetFakeProductOsVersions(int count, RangeConfigProductOSVersion rangeConfig)
        {
            var fakeProductOsVersions = new List<ProductOSVersion>();
            var faker = new Faker("en"); // default en

            for(int i = 0; i < count; )
            {
                var osId = faker.Random.Number(rangeConfig.MinOperatingSystemId, rangeConfig.MaxOperatingSystemId);
                var versionId = faker.Random.Number(rangeConfig.MinVersionId, rangeConfig.MaxVersionId);
                var prodId = faker.Random.Number(rangeConfig.MinProductId, rangeConfig.MaxProductId);
                var productOsVersion = new ProductOSVersion()
                { Id = i + 1, ProductId = prodId, OperatingSystemId = osId, VersionId = versionId, };

                if(fakeProductOsVersions.Exists(x => x.OperatingSystemId == osId &&
                    x.VersionId == versionId &&
                    x.ProductId == prodId))
                {
                    continue;
                } else
                {
                    fakeProductOsVersions.Add(productOsVersion);
                    i++;
                }
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
                    Description = $"{faker.Hacker.Phrase()} {faker.System.Exception()} { faker.Lorem.Paragraph() }",
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
