using BugTracker.Data.EFCoreExtensions;
using BugTracker.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Data.Repository
{
    public class BugTrackerRepository : IBugTrackerRepository
    {
        private ApplicationDbContext _dbContext;

        public BugTrackerRepository(ApplicationDbContext dbContext) { _dbContext = dbContext; }


        /// <summary>
        /// 1 Get all issues (all products)
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<List<IssueViewModel>> GetAllIssuesByStatusAsync(string status)
        {
            var result = await _dbContext.LoadStoredProc("GET_ALL_ISSUES_BY_STATUS")
                .WithSqlParam("Status", status)
                .ExecuteStoredProc<IssueViewModel>();

            return result.ToList();
        }


        /// <summary>
        /// 2 Get all issues for a product (all versions)
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<List<IssueViewModel>> GetAllIssuesBy_ProductName_StatusAsync(string productName,
                                                                                       string status)
        {
            var result = await _dbContext.LoadStoredProc("GET_ALL_ISSUES_BY_PRODUCTNAME_STATUS")
                .WithSqlParam("ProductName", productName)
                .WithSqlParam("Status", status)
                .ExecuteStoredProc<IssueViewModel>();

            return result.ToList();
        }


        /// <summary>
        /// 3 Get all issues for a product (single version)
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="version"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<List<IssueViewModel>> GetAllIssuesBy_ProductName_Version_StatusAsync(string productName,
                                                                                               string version,
                                                                                               string status)
        {
            var result = await _dbContext.LoadStoredProc("GET_ALL_ISSUES_BY_PRODUCTNAME_VERSION_STATUS")
                .WithSqlParam("ProductName", productName)
                .WithSqlParam("Version", version)
                .WithSqlParam("Status", status)
                .ExecuteStoredProc<IssueViewModel>();

            return result.ToList();
        }


        /// <summary>
        /// 4 Get all issues within date range for a product (all versions)
        /// </summary>
        /// <param name="minDate"></param>
        /// <param name="maxDate"></param>
        /// <param name="productName"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<List<IssueViewModel>> GetAllIssuesBy_DateRange_ProductName_StatusAsync(string minDate,
                                                                                                 string maxDate,
                                                                                                 string productName,
                                                                                                 string status)
        {
            var result = await _dbContext.LoadStoredProc("GET_ALL_ISSUES_BY_DATERANGE_PRODUCTNAME_STATUS")
                .WithSqlParam("MinDate", minDate)
                .WithSqlParam("MaxDate", maxDate)
                .WithSqlParam("ProductName", productName)
                .WithSqlParam("Status", status)
                .ExecuteStoredProc<IssueViewModel>();

            return result.ToList();
        }


        /// <summary>
        /// 5 Get all issues within date range for a product (single version)
        /// </summary>
        /// <param name="minDate"></param>
        /// <param name="maxDate"></param>
        /// <param name="productName"></param>
        /// <param name="version"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<List<IssueViewModel>> GetAllIssuesBy_DateRange_ProductName_Version_StatusAsync(string minDate,
                                                                                                         string maxDate,
                                                                                                         string productName,
                                                                                                         string version,
                                                                                                         string status)
        {
            var result = await _dbContext.LoadStoredProc("GET_ALL_ISSUES_BY_DATERANGE_PRODUCTNAME_VERSION_STATUS")
                .WithSqlParam("MinDate", minDate)
                .WithSqlParam("MaxDate", maxDate)
                .WithSqlParam("ProductName", productName)
                .WithSqlParam("Version", version)
                .WithSqlParam("Status", status)
                .ExecuteStoredProc<IssueViewModel>();

            return result.ToList();
        }


        /// <summary>
        /// 6 Get all issues containing list of keywords (all products)
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<List<IssueViewModel>> GetAllIssuesBy_Keywords_StatusAsync(List<string> keywords,
                                                                                    string status)
        {
            string _keywords = $";{String.Join(";", keywords.ToArray())};";

            var result = await _dbContext.LoadStoredProc("GET_ALL_ISSUES_BY_KEYWORDS_STATUS")
                .WithSqlParam("Keywords", _keywords)
                .WithSqlParam("Status", status)
                .ExecuteStoredProc<IssueViewModel>();

            return result.ToList();
        }


        /// <summary>
        /// 7 Get all issues for a product containing list of keywords (all versions)
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="keywords"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<List<IssueViewModel>> GetAllIssuesBy_ProductName_Keywords_StatusAsync(string productName,
                                                                                                List<string> keywords,
                                                                                                string status)
        {
            string _keywords = $";{String.Join(";", keywords.ToArray())};";

            var result = await _dbContext.LoadStoredProc("GET_ALL_ISSUES_BY_PRODUCTNAME_KEYWORDS_STATUS")
                .WithSqlParam("ProductName", productName)
                .WithSqlParam("Keywords", _keywords)
                .WithSqlParam("Status", status)
                .ExecuteStoredProc<IssueViewModel>();

            return result.ToList();
        }


        /// <summary>
        /// 8 Get all issues for a product containing list of keywords (single version)
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="version"></param>
        /// <param name="keywords"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<List<IssueViewModel>> GetAllIssuesBy_ProductName_Version_Keywords_StatusAsync(string productName,
                                                                                                        string version,
                                                                                                        List<string> keywords,
                                                                                                        string status)
        {
            string _keywords = $";{String.Join(";", keywords.ToArray())};";

            var result = await _dbContext.LoadStoredProc("GET_ALL_ISSUES_BY_PRODUCTNAME_VERSION_KEYWORDS_STATUS")
                .WithSqlParam("ProductName", productName)
                .WithSqlParam("Version", version)
                .WithSqlParam("Keywords", _keywords)
                .WithSqlParam("Status", status)
                .ExecuteStoredProc<IssueViewModel>();

            return result.ToList();
        }


        /// <summary>
        /// 9 Get all issues within date range for a product containing list of keywords (all versions)
        /// </summary>
        /// <param name="minDate"></param>
        /// <param name="maxDate"></param>
        /// <param name="productName"></param>
        /// <param name="keywords"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<List<IssueViewModel>> GetAllIssuesBy_DateRange_ProductName_Keywords_StatusAsync(string minDate,
                                                                                                          string maxDate,
                                                                                                          string productName,
                                                                                                          List<string> keywords,
                                                                                                          string status)
        {
            string _keywords = $";{String.Join(";", keywords.ToArray())};";

            var result = await _dbContext.LoadStoredProc("GET_ALL_ISSUES_BY_DATERANGE_PRODUCTNAME_KEYWORDS_STATUS")
                .WithSqlParam("MinDate", minDate)
                .WithSqlParam("MaxDate", maxDate)
                .WithSqlParam("ProductName", productName)
                .WithSqlParam("Keywords", _keywords)
                .WithSqlParam("Status", status)
                .ExecuteStoredProc<IssueViewModel>();

            return result.ToList();
        }


        /// <summary>
        /// 10 Get all issues within date range for a product containing list of keywords (single version)
        /// </summary>
        /// <param name="minDate"></param>
        /// <param name="maxDate"></param>
        /// <param name="productName"></param>
        /// <param name="version"></param>
        /// <param name="keywords"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<List<IssueViewModel>> GetAllIssuesBy_DateRange_ProductName_Version_Keywords_StatusAsync(string minDate,
                                                                                                                  string maxDate,
                                                                                                                  string productName,
                                                                                                                  string version,
                                                                                                                  List<string> keywords,
                                                                                                                  string status)
        {
            string _keywords = $";{String.Join(";", keywords.ToArray())};";

            var result = await _dbContext.LoadStoredProc("GET_ALL_ISSUES_BY_DATERANGE_PRODUCTNAME_VERSION_KEYWORDS_STATUS")
                .WithSqlParam("MinDate", minDate)
                .WithSqlParam("MaxDate", maxDate)
                .WithSqlParam("ProductName", productName)
                .WithSqlParam("Keywords", _keywords)
                .WithSqlParam("Version", version)
                .WithSqlParam("Status", status)
                .ExecuteStoredProc<IssueViewModel>();

            return result.ToList();
        }
    }
}
