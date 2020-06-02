using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Data.Utils
{
    public class RangeConfigProductOSVersion
    {
        public int MinProductId { get; set; }

        public int MaxProductId { get; set; }

        public int MinVersionId { get; set; }

        public int MaxVersionId { get; set; }

        public int MinOperatingSystemId { get; set; }

        public int MaxOperatingSystemId { get; set; }
    }
}
