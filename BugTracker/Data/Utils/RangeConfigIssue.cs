using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Data.Utils
{
    public class RangeConfigIssue
    {
        public int MinProductOSVersionId { get; set; }

        public int MaxProductOSVersionId { get; set; }

        public int MinIssueStatusId { get; set; }

        public int MaxIssueStatusId { get; set; }
    }
}
