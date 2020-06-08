using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests.TestData
{
    public class DateRangeProductNameVersionKeywordsStatusTestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            { "06/06/2020", "08/06/2020", "Workout Planner", "1.0", new List<string> { "calculating" }, "created", 1 },
            new object[]
            { "06/06/2020", "08/06/2020", "Workout Planner", "2.3", new List<string> { "calculating" }, "created", 0 },
            new object[]
            {
                "06/06/2020",
                "08/06/2020",
                "Workout Planner",
                "1.0",
                new List<string>
                { "SAS", "interface" },
                "in progress",
                1
            },
            new object[]
            { "06/06/2020", "08/06/2020", "Workout Planner", "1.2", new List<string> { "quantifying" }, "resolved", 1 },
            new object[]
            {
                "06/06/2020",
                "08/06/2020",
                "Workout Planner",
                "2.1",
                new List<string>
                { "JSON", "program" },
                "closed",
                1
            },
        };

        public IEnumerator<object[]> GetEnumerator() { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}
