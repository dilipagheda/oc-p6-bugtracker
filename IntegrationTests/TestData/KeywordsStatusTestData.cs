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
            { new List<string> { "Sunt", "inventore" }, "created" },
            new object[]
            { new List<string> { "inventore", "Sunt", }, "created" },
            new object[]
            { new List<string> { "placeat", "Sapiente", "dicta" }, "in progress" },
            new object[]
            { new List<string> { "perspiciatis" }, "resolved" },
            new object[]
            { new List<string> { "voluptate", "asperiores", "voluptatibus", "deserunt" }, "closed" },
        };

        public IEnumerator<object[]> GetEnumerator() { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}
