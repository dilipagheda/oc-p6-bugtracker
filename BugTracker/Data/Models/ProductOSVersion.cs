using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Data.Models
{
    public class ProductOSVersion
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int OperatingSystemId { get; set; }

        public OperatingSystem OperatingSystem { get; set; }

        public int VersionId { get; set; }

        public Version Version { get; set; }
    }
}
