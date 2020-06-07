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
            {
                "04/06/2020",
                "04/06/2020",
                "Intelligent Concrete Soap",
                new List<string>
                { "excepturi", "quas" },
                "created"
            },
            new object[]
            {
                "03/06/2020",
                "03/06/2020",
                "Handmade Rubber Shoes",
                new List<string>
                { "perferendis", "dolores", "iste" },
                "in progress"
            },
            new object[]
            { "04/06/2020", "04/06/2020", "Unbranded Plastic Soap", new List<string> { "autem" }, "resolved" },
            new object[]
            {
                "03/06/2020",
                "04/06/2020",
                "Tasty Cotton Soap",
                new List<string>
                { "minus", "Laboriosam", "autem", "odio" },
                "closed"
            },
        };

        public IEnumerator<object[]> GetEnumerator() { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}
