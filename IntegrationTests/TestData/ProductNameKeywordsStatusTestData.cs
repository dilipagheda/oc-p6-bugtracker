using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests.TestData
{
    public class ProductNameKeywordsStatusTestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            { "Workout Planner", new List<string> { "need", "virtual", "We" }, "created", 4 },
            new object[]
            { "Workout Planner", new List<string> { "need", "virtual", "We" }, "in progress", 0 },
            new object[]
            { "Day Trader Wannabe", new List<string> { "need", "virtual", "We" }, "in progress", 2 },
            new object[]
            { "Workout Planner", new List<string> { "need", "virtual", "We" }, "resolved", 1 },
            new object[]
            { "Workout Planner", new List<string> { "need", "virtual", "We" }, "closed", 2 },
        };

        public IEnumerator<object[]> GetEnumerator() { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}
