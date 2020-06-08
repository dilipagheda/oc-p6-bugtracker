using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests.TestData
{
    public class ProductNameVersionKeywordsStatusTestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            { "Workout Planner", "1.0", new List<string> { "need", "virtual", "we" }, "created", 3 },
            new object[]
            { "Workout Planner", "1.0", new List<string> { "SAS", "interface" }, "in progress", 1 },
            new object[]
            { "Workout Planner", "1.2", new List<string> { "anything", "do" }, "resolved", 1 },
            new object[]
            { "Workout Planner", "2.1", new List<string> { "JSON" }, "closed", 1 },
            new object[]
            { "Workout Planner", "2.1", new List<string> { "SMTP" }, "closed", 0 },
        };

        public IEnumerator<object[]> GetEnumerator() { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}
