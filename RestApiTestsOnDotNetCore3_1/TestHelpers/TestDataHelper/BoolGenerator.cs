using System;
using System.ComponentModel.DataAnnotations;

namespace RestApiTestsOnDotNetCore3_1.TestHelpers.TestDataHelper
{
    public static class BoolGenerator
    {
        public static bool GetRandomBool([Range(0, 100)] int probabilityOfTrue = 50)
        {
            var random = new Random();
            return random.Next(100) <= probabilityOfTrue;
        }
    }
}
