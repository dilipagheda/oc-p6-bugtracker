using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Data.ViewModels
{
    [NotMapped]
    public class IssueViewModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string VersionName { get; set; }

        public string OSName { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public string Resolution { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ResolutionDate { get; set; }
    }
}
