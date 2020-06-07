using BugTracker.Data;
using BugTracker.Data.Repository;
using IntegrationTests.TestData;
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
        [InlineData("closed")]
        [InlineData("created")]
        [InlineData("in progress")]
        [InlineData("resolved")]
        public async Task GetAllIssuesByStatus_ShouldReturnCorrectResult(string status)
        {
            //Arrange
            var sut = new BugTrackerRepository(_applicationDbContext);

            //Act
            var result = await sut.GetAllIssuesByStatusAsync(status);

            //Assert
            Assert.NotEmpty(result);
            var unexpectedItems = result.Where(x => x.Status.ToLower() != status.ToLower()).ToList();
            Assert.Empty(unexpectedItems);
        }

        [Theory]
        [InlineData("Intelligent Concrete Soap", "created")]
        [InlineData("Incredible Granite Bacon", "in progress")]
        [InlineData("Intelligent Fresh Pizza", "closed")]
        [InlineData("Gorgeous Soft Pizza", "resolved")]
        public async Task GetAllIssuesBy_ProductName_Status_ShouldReturnCorrectResult(string productName, string status)
        {
            //Arrange
            var sut = new BugTrackerRepository(_applicationDbContext);

            //Act
            var result = await sut.GetAllIssuesBy_ProductName_StatusAsync(productName, status);

            //Assert
            Assert.NotEmpty(result);
            var unexpectedItems = result.Where(x => x.Status.ToLower() != status.ToLower() &&
                x.ProductName.ToLower() != productName.ToLower())
                .ToList();
            Assert.Empty(unexpectedItems);
        }

        [Theory]
        [InlineData("Licensed Cotton Table", "9.9.8.7", "resolved")]
        [InlineData("Rustic Concrete Mouse", "3.9.7.3", "created")]
        [InlineData("Sleek Plastic Sausages", "9.8.8.7", "in progress")]
        [InlineData("Tasty Cotton Soap", "3.2.6.0", "closed")]
        public async Task GetAllIssuesBy_ProductName_Version_Status_ShouldReturnCorrectResult(string productName,
                                                                                              string version,
                                                                                              string status)
        {
            //Arrange
            var sut = new BugTrackerRepository(_applicationDbContext);

            //Act
            var result = await sut.GetAllIssuesBy_ProductName_StatusAsync(productName, status);

            //Assert
            Assert.NotEmpty(result);
            var unexpectedItems = result.Where(x => x.Status.ToLower() != status.ToLower() &&
                x.ProductName.ToLower() != productName.ToLower() &&
                x.VersionName.ToLower() != version.ToLower())
                .ToList();
            Assert.Empty(unexpectedItems);
        }

        [Theory]
        [InlineData("04/06/2020","05/06/2020","Intelligent Concrete Soap","created")]
        [InlineData("04/06/2020", "05/06/2020", "Ergonomic Fresh Gloves", "resolved")]
        [InlineData("04/06/2020", "05/06/2020", "Small Soft Tuna", "in progress")]
        [InlineData("01/06/2020", "05/06/2020", "Tasty Cotton Soap", "closed")]
        public async Task GetAllIssuesBy_DateRange_ProductName_StatusAsync(string minDate,
                                                                           string maxDate,
                                                                           string productName,
                                                                           string status)
        {
            //Arrange
            var sut = new BugTrackerRepository(_applicationDbContext);

            //Act
            var result = await sut.GetAllIssuesBy_DateRange_ProductName_StatusAsync(minDate,
                                                                                    maxDate,
                                                                                    productName,
                                                                                    status);

            //Assert
            Assert.NotEmpty(result);
            var unexpectedItems = result.Where(x => x.Status.ToLower() != status.ToLower() &&
                x.ProductName.ToLower() != productName.ToLower() &&
                x.CreationDate >= DateTime.Parse(minDate, new CultureInfo("en-AU")) &&
                x.CreationDate <= DateTime.Parse(minDate, new CultureInfo("en-AU")))
                .ToList();

            Assert.Empty(unexpectedItems);
        }

        [Theory]
        [InlineData("04/06/2020", "05/06/2020", "Intelligent Concrete Soap", "5.6.2.3", "created")]
        [InlineData("04/06/2020", "05/06/2020", "Ergonomic Fresh Gloves", "8.1.6.0","resolved")]
        [InlineData("04/06/2020", "05/06/2020", "Small Soft Tuna", "9.8.8.7", "in progress")]
        [InlineData("01/06/2020", "05/06/2020", "Tasty Cotton Soap", "3.2.6.0","closed")]
        public async Task GetAllIssuesBy_DateRange_ProductName_Version_Status_ShouldReturnCorrectResult(string minDate,
                                                                                                        string maxDate,
                                                                                                        string productName,
                                                                                                        string version,
                                                                                                        string status)
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
            Assert.NotEmpty(result);
            var unexpectedItems = result.Where(x => x.Status.ToLower() != status.ToLower() &&
                x.ProductName.ToLower() != productName.ToLower() &&
                x.VersionName.ToLower() != version.ToLower() &&
                x.CreationDate >= DateTime.Parse(minDate, new CultureInfo("en-AU")) &&
                x.CreationDate <= DateTime.Parse(minDate, new CultureInfo("en-AU")))
                .ToList();

            Assert.Empty(unexpectedItems);
        }

        [Theory, ClassData(typeof(KeywordsStatusTestData))]
        public async Task GetAllIssuesBy_Keywords_StatusAsync(List<string> keywords, string status)
        {
            //Arrange
            var sut = new BugTrackerRepository(_applicationDbContext);

            //Act
            var result = await sut.GetAllIssuesBy_Keywords_StatusAsync(keywords, status);

            //Assert
            Assert.NotEmpty(result);
            var unexpectedItems = result.Where(x => x.Status.ToLower() != status.ToLower()).ToList();

            Assert.Empty(unexpectedItems);
        }

        [Theory, ClassData(typeof(ProductNameKeywordsStatusTestData))]
        public async Task GetAllIssuesBy_ProductName_Keywords_StatusAsync(string productName,
                                                                          List<string> keywords,
                                                                          string status)
        {
            //Arrange
            var sut = new BugTrackerRepository(_applicationDbContext);

            //Act
            var result = await sut.GetAllIssuesBy_ProductName_Keywords_StatusAsync(productName, keywords, status);

            //Assert
            Assert.NotEmpty(result);
            var unexpectedItems = result.Where(x => x.Status.ToLower() != status.ToLower()).ToList();

            Assert.Empty(unexpectedItems);
        }

        [Theory, ClassData(typeof(ProductNameVersionKeywordsStatusTestData))]
        public async Task GetAllIssuesBy_ProductName_Version_Keywords_StatusAsync(string productName,
                                                                                  string version,
                                                                                  List<string> keywords,
                                                                                  string status)
        {
            //Arrange
            var sut = new BugTrackerRepository(_applicationDbContext);

            //Act
            var result = await sut.GetAllIssuesBy_ProductName_Version_Keywords_StatusAsync(productName,
                                                                                           version,
                                                                                           keywords,
                                                                                           status);

            //Assert
            Assert.NotEmpty(result);
            var unexpectedItems = result.Where(x => x.Status.ToLower() != status.ToLower()).ToList();

            Assert.Empty(unexpectedItems);
        }

        [Theory, ClassData(typeof(DateRangeProductNameKeywordsStatusTestData))]
        public async Task GetAllIssuesBy_DateRange_ProductName_Keywords_StatusAsync(string minDate,
                                                                                    string maxDate,
                                                                                    string productName,
                                                                                    List<string> keywords,
                                                                                    string status)
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
            Assert.NotEmpty(result);
            var unexpectedItems = result.Where(x => x.Status.ToLower() != status.ToLower()).ToList();

            Assert.Empty(unexpectedItems);
        }

        [Theory, ClassData(typeof(DateRangeProductNameVersionKeywordsStatusTestData))]
        public async Task GetAllIssuesBy_DateRange_ProductName_Version_Keywords_StatusAsync(string minDate,
                                                                                            string maxDate,
                                                                                            string productName,
                                                                                            string version,
                                                                                            List<string> keywords,
                                                                                            string status)
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
            Assert.NotEmpty(result);
            var unexpectedItems = result.Where(x => x.Status.ToLower() != status.ToLower()).ToList();

            Assert.Empty(unexpectedItems);
        }
    }
}
