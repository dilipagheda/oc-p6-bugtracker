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
            { "Intelligent Concrete Soap", "5.6.2.3", new List<string> { "excepturi", "quas" }, "created" },
            new object[]
            { "Handmade Rubber Shoes", "9.8.8.7", new List<string> { "perferendis", "dolores", "iste" }, "in progress" },
            new object[]
            { "Unbranded Plastic Soap", "6.2.4.7", new List<string> { "autem" }, "resolved" },
            new object[]
            { "Tasty Cotton Soap", "3.2.6.0", new List<string> { "minus", "Laboriosam", "autem", "odio" }, "closed" },
        };

        public IEnumerator<object[]> GetEnumerator() { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}
