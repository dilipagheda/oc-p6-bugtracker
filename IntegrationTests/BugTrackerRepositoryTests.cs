using BugTracker.Data;
using BugTracker.Data.Repository;
using IntegrationTests.TestData;
using IntegrationTests.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class BugTrackerRepositoryTests
    {
        private ApplicationDbContext _applicationDbContext;
        private readonly string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=BugTracker;Trusted_Connection=True;MultipleActiveResultSets=true";

        public BugTrackerRepositoryTests()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(_connectionString).Options;

            _applicationDbContext = new ApplicationDbContext(dbOptions);
        }

        [Theory]
        [InlineData("closed",10)]
        [InlineData("created",14)]
        [InlineData("in progress",14)]
        [InlineData("resolved",12)]
        public async Task GetAllIssuesByStatus_ShouldReturnCorrectResult(string status, int totalCount)
        {
            //Arrange
            var sut = new BugTrackerRepository(_applicationDbContext);

            //Act
            var result = await sut.GetAllIssuesByStatusAsync(status);

            //Assert
            Assert.Equal(totalCount, result.Count);
            var unexpectedItems = result.Where(x => x.Status.ToLower() != status.ToLower()).ToList();
            Assert.Empty(unexpectedItems);
        }

        [Theory]
        [InlineData("Workout Planner", "created",6)]
        [InlineData("Workout Planner", "in progress",1)]
        [InlineData("Workout Planner", "closed",2)]
        [InlineData("Workout Planner", "resolved",1)]
        public async Task GetAllIssuesBy_ProductName_Status_ShouldReturnCorrectResult(string productName,
                                                                                      string status,
                                                                                      int totalCount)
        {
            //Arrange
            var sut = new BugTrackerRepository(_applicationDbContext);

            //Act
            var result = await sut.GetAllIssuesBy_ProductName_StatusAsync(productName, status);

            //Assert
            Assert.Equal(totalCount, result.Count);
            var unexpectedItems = result.Where(x => x.Status.ToLower() != status.ToLower() &&
                x.ProductName.ToLower() != productName.ToLower())
                .ToList();
            Assert.Empty(unexpectedItems);
        }

        [Theory]
        [InlineData("Workout Planner", "1.2", "resolved",1)]
        [InlineData("Workout Planner", "1.0", "created",3)]
        [InlineData("Workout Planner", "1.0", "in progress",1)]
        [InlineData("Workout Planner", "2.3", "closed",1)]
        public async Task GetAllIssuesBy_ProductName_Version_Status_ShouldReturnCorrectResult(string productName,
                                                                                              string version,
                                                                                              string status,
                                                                                              int totalCount)
        {
            //Arrange
            var sut = new BugTrackerRepository(_applicationDbContext);

            //Act
            var result = await sut.GetAllIssuesBy_ProductName_Version_StatusAsync(productName, version, status);

            //Assert
            Assert.Equal(totalCount, result.Count);
            var unexpectedItems = result.Where(x => x.Status.ToLower() != status.ToLower() &&
                x.ProductName.ToLower() != productName.ToLower() &&
                x.VersionName.ToLower() != version.ToLower())
                .ToList();
            Assert.Empty(unexpectedItems);
        }

        [Theory]
        [InlineData("06/06/2020", "06/06/2020", "Workout Planner", "created",1)]
        [InlineData("08/06/2020", "10/06/2020", "Workout Planner", "created", 0)]
        [InlineData("06/06/2020", "07/06/2020", "Workout Planner", "resolved",1)]
        [InlineData("06/06/2020", "07/06/2020", "Workout Planner", "in progress",1)]
        [InlineData("06/06/2020", "07/06/2020", "Workout Planner", "closed",2)]
        public async Task GetAllIssuesBy_DateRange_ProductName_StatusAsync(string minDate,
                                                                           string maxDate,
                                                                           string productName,
                                                                           string status,
                                                                           int totalCount)
        {
            //Arrange
            var sut = new BugTrackerRepository(_applicationDbContext);

            //Act
            var result = await sut.GetAllIssuesBy_DateRange_ProductName_StatusAsync(minDate,
                                                                                    maxDate,
                                                                                    productName,
                                                                                    status);

            //Assert
            Assert.Equal(totalCount, result.Count);
            var unexpectedItems = result.Where(x => x.Status.ToLower() != status.ToLower() &&
                x.ProductName.ToLower() != productName.ToLower() &&
                x.CreationDate >= DateTime.Parse(minDate, new CultureInfo("en-AU")) &&
                x.CreationDate <= DateTime.Parse(minDate, new CultureInfo("en-AU")))
                .ToList();

            Assert.Empty(unexpectedItems);
        }

        [Theory]
        [InlineData("06/06/2020", "08/06/2020", "Workout Planner","1.0", "created", 3)]
        [InlineData("06/06/2020", "08/06/2020", "Workout Planner", "9.0", "created", 0)]
        [InlineData("06/06/2020", "07/06/2020", "Workout Planner","1.2", "resolved", 1)]
        [InlineData("06/06/2020", "07/06/2020", "Workout Planner","1.0", "in progress", 1)]
        [InlineData("06/06/2020", "07/06/2020", "Workout Planner","2.3", "closed", 1)]
        public async Task GetAllIssuesBy_DateRange_ProductName_Version_Status_ShouldReturnCorrectResult(string minDate,
                                                                                                        string maxDate,
                                                                                                        string productName,
                                                                                                        string version,
                                                                                                        string status,
                                                                                                        int totalCount)
        {
            //Arrange
            var sut = new BugTrackerRepository(_applicationDbContext);

            //Act
            var result = await sut.GetAllIssuesBy_DateRange_ProductName_Version_StatusAsync(minDate,
                                                                                            maxDate,
                                                                                            productName,
                                                                                            version,
                                                                                            status);

            //Assert
            Assert.Equal(totalCount, result.Count);
            var unexpectedItems = result.Where(x => x.Status.ToLower() != status.ToLower() &&
                x.ProductName.ToLower() != productName.ToLower() &&
                x.VersionName.ToLower() != version.ToLower() &&
                x.CreationDate >= DateTime.Parse(minDate, new CultureInfo("en-AU")) &&
                x.CreationDate <= DateTime.Parse(minDate, new CultureInfo("en-AU")))
                .ToList();

            Assert.Empty(unexpectedItems);
        }

        [Theory, ClassData(typeof(KeywordsStatusTestData))]
        public async Task GetAllIssuesBy_Keywords_StatusAsync(List<string> keywords, string status, int totalCount)
        {
            //Arrange
            var sut = new BugTrackerRepository(_applicationDbContext);

            //Act
            var result = await sut.GetAllIssuesBy_Keywords_StatusAsync(keywords, status);

            //Assert
            Assert.Equal(totalCount, result.Count);
            //Check for keywords
            foreach(var item in result)
            {
                Assert.True(Helper.IsMatch(item.Description, keywords));
            }

            var unexpectedItems = result.Where(x => x.Status.ToLower() != status.ToLower()).ToList();

            Assert.Empty(unexpectedItems);
        }

        [Theory, ClassData(typeof(ProductNameKeywordsStatusTestData))]
        public async Task GetAllIssuesBy_ProductName_Keywords_StatusAsync(string productName,
                                                                          List<string> keywords,
                                                                          string status,
                                                                          int totalCount)
        {
            //Arrange
            var sut = new BugTrackerRepository(_applicationDbContext);

            //Act
            var result = await sut.GetAllIssuesBy_ProductName_Keywords_StatusAsync(productName, keywords, status);

            //Assert
            Assert.Equal(totalCount, result.Count);
            //Check for keywords
            foreach(var item in result)
            {
                Assert.True(Helper.IsMatch(item.Description, keywords));
                Assert.Equal(productName, item.ProductName);
            }
            var unexpectedItems = result.Where(x => x.Status.ToLower() != status.ToLower()).ToList();

            Assert.Empty(unexpectedItems);
        }

        [Theory, ClassData(typeof(ProductNameVersionKeywordsStatusTestData))]
        public async Task GetAllIssuesBy_ProductName_Version_Keywords_StatusAsync(string productName,
                                                                                  string version,
                                                                                  List<string> keywords,
                                                                                  string status,
                                                                                  int totalCount)
        {
            //Arrange
            var sut = new BugTrackerRepository(_applicationDbContext);

            //Act
            var result = await sut.GetAllIssuesBy_ProductName_Version_Keywords_StatusAsync(productName,
                                                                                           version,
                                                                                           keywords,
                                                                                           status);

            //Assert
            Assert.Equal(totalCount, result.Count);
            //Check for keywords
            foreach(var item in result)
            {
                Assert.True(Helper.IsMatch(item.Description, keywords));
                Assert.Equal(productName, item.ProductName);
                Assert.Equal(version, item.VersionName);
            }
            var unexpectedItems = result.Where(x => x.Status.ToLower() != status.ToLower()).ToList();

            Assert.Empty(unexpectedItems);
        }

        [Theory, ClassData(typeof(DateRangeProductNameKeywordsStatusTestData))]
        public async Task GetAllIssuesBy_DateRange_ProductName_Keywords_StatusAsync(string minDate,
                                                                                    string maxDate,
                                                                                    string productName,
                                                                                    List<string> keywords,
                                                                                    string status,
                                                                                    int totalCount)
        {
            //Arrange
            var sut = new BugTrackerRepository(_applicationDbContext);

            //Act
            var result = await sut.GetAllIssuesBy_DateRange_ProductName_Keywords_StatusAsync(minDate,
                                                                                             maxDate,
                                                                                             productName,
                                                                                             keywords,
                                                                                             status);

            //Assert
            Assert.Equal(totalCount, result.Count);
            //Check for keywords
            foreach(var item in result)
            {
                Assert.True(Helper.IsMatch(item.Description, keywords));
                Assert.Equal(productName, item.ProductName);
            }
            var unexpectedItems = result.Where(x => x.Status.ToLower() != status.ToLower() &&
                x.CreationDate >= DateTime.Parse(minDate, new CultureInfo("en-AU")) &&
                x.CreationDate <= DateTime.Parse(minDate, new CultureInfo("en-AU")))
                .ToList();

            Assert.Empty(unexpectedItems);
        }

        [Theory, ClassData(typeof(DateRangeProductNameVersionKeywordsStatusTestData))]
        public async Task GetAllIssuesBy_DateRange_ProductName_Version_Keywords_StatusAsync(string minDate,
                                                                                            string maxDate,
                                                                                            string productName,
                                                                                            string version,
                                                                                            List<string> keywords,
                                                                                            string status,
                                                                                            int totalCount)
        {
            //Arrange
            var sut = new BugTrackerRepository(_applicationDbContext);

            //Act
            var result = await sut.GetAllIssuesBy_DateRange_ProductName_Version_Keywords_StatusAsync(minDate,
                                                                                                     maxDate,
                                                                                                     productName,
                                                                                                     version,
                                                                                                     keywords,
                                                                                                     status);

            //Assert
            Assert.Equal(totalCount, result.Count);
            //Check for keywords
            foreach(var item in result)
            {
                Assert.True(Helper.IsMatch(item.Description, keywords));
                Assert.Equal(productName, item.ProductName);
                Assert.Equal(version, item.VersionName);
            }
            var unexpectedItems = result.Where(x => x.Status.ToLower() != status.ToLower() &&
                x.CreationDate >= DateTime.Parse(minDate, new CultureInfo("en-AU")) &&
                x.CreationDate <= DateTime.Parse(minDate, new CultureInfo("en-AU")))
                .ToList();

            Assert.Empty(unexpectedItems);
        }
    }
}
