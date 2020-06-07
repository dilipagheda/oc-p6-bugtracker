﻿using System;
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
            { "Intelligent Concrete Soap", new List<string> { "excepturi", "quas" }, "created" },
            new object[]
            { "Handmade Rubber Shoes", new List<string> { "perferendis", "dolores", "iste" }, "in progress" },
            new object[]
            { "Unbranded Plastic Soap", new List<string> { "autem" }, "resolved" },
            new object[]
            { "Tasty Cotton Soap", new List<string> { "minus", "Laboriosam", "autem", "odio" }, "closed" },
        };

        public IEnumerator<object[]> GetEnumerator() { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}
