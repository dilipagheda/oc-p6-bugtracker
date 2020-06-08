using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests.Utils
{
    public static class Helper
    {
        public static bool IsMatch(string desc, List<string> keywords)
        {
            bool isMatchFound = false;
            foreach(var keyword in keywords)
            {
                if(desc.ToLower().Contains(keyword.ToLower()))
                {
                    isMatchFound = true;
                    break;
                }
            }
            return isMatchFound;
        }
    }
}
