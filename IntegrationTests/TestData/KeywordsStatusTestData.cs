using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests.TestData
{
    public class KeywordsStatusTestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            { new List<string> { "need", "virtual", "we" }, "created", 9 },
            new object[]
            { new List<string> { "need", "virtual", "we" }, "in progress", 7 },
            new object[]
            { new List<string> { "need", "virtual", "we" }, "resolved", 6 },
            new object[]
            { new List<string> { "need", "virtual", "we" }, "closed", 7 },
        };

        public IEnumerator<object[]> GetEnumerator() { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}
