using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Data.Models
{
    public class Issue
    {
        public int Id { get; set; }

        public int ProductOSVersionId { get; set; }

        public ProductOSVersion ProductOSVersion { get; set; }

        public int IssueStatusId { get; set; }

        public IssueStatus IssueStatus { get; set; }

        public string Description { get; set; }

        public string Resolution { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ResolutionDate { get; set; }
    }
}
