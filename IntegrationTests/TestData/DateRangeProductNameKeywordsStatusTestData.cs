using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests.TestData
{
    public class DateRangeProductNameKeywordsStatusTestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            { "06/06/2020", "08/06/2020", "Workout Planner", new List<string> { "calculating" }, "created", 1 },
            new object[]
            { "06/06/2020", "08/06/2020", "Workout Planner", new List<string> { "SAS", "interface" }, "in progress", 1 },
            new object[]
            { "06/06/2020", "08/06/2020", "Workout Planner", new List<string> { "calculating" }, "in progress", 0 },
            new object[]
            { "06/06/2020", "08/06/2020", "Workout Planner", new List<string> { "quantifying" }, "resolved", 1 },
            new object[]
            { "06/06/2020", "08/06/2020", "Workout Planner", new List<string> { "JSON" }, "closed", 1 },
        };

        public IEnumerator<object[]> GetEnumerator() { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}
