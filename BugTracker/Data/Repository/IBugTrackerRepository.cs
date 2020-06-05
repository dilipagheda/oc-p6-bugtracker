using BugTracker.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Data.Repository
{
    public interface IBugTrackerRepository
    {
        Task<List<IssueViewModel>> GetAllIssuesByStatusAsync(string status);
    }
}
