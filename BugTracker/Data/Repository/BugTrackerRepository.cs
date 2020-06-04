using BugTracker.Data.Models;
using BugTracker.Data.ViewModels;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Data.Repository
{
    public class BugTrackerRepository : IBugTrackerRepository
    {
        private ApplicationDbContext _dbContext;
        private readonly IConfiguration _config;

        public BugTrackerRepository(ApplicationDbContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        public IDbConnection Connection
        {
            get { return new SqlConnection(_config.GetConnectionString("DefaultConnection")); }
        }

        public List<IssueViewModel> GetAllIssuesByStatusAsync(string status)
        {
            using(IDbConnection conn = Connection)
            {
                conn.Open();
                var issues = conn.Query<IssueViewModel>("GET_ALL_ISSUES_BY_STATUS",
                                                        new { Status = status },
                                                        commandType: CommandType.StoredProcedure)
                    .ToList();
                return issues;
            }
        }
    }
}
