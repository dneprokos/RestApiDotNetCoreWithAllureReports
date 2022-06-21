using System;
using System.Collections.Generic;
using FluentAssertions;

namespace RestApiTestsOnDotNetCore3_1.TestHelpers.TestDataHelper
{
    public static class DecimalGenerator
    {
        private static readonly Random Random = new Random();

        public static decimal GenerateRandomDecimal(int maxBeforeDecimalPlaces = 9, int decimalPlaces = 4)
        {
            var first = Random.Next(0, maxBeforeDecimalPlaces);
            var decimalPlacesInt = GenerateDecimalPlaces(decimalPlaces);

            return decimal.Parse($"{first}.{decimalPlacesInt}");
        }

        public static List<decimal> GenerateRandomDecimals(int recordsCount, int maxBeforeDecimalPlaces = 9, int decimalPlaces = 4)
        {
            recordsCount.Should().BeGreaterThan(0);
            var randomDecimals = new List<decimal>();
            for (var i = 0; i < recordsCount; i++)
            {
                randomDecimals.Add(GenerateRandomDecimal(maxBeforeDecimalPlaces, decimalPlaces));
            }

            return randomDecimals;
        }

        private static int GenerateDecimalPlaces(int decimalPlaces)
        {
            decimalPlaces.Should().NotBeInRange(0, int.MinValue);
            var decimalPlacesString = "";

            for (var i = 0; i < decimalPlaces; i++)
            {
                decimalPlacesString += Random.Next(0, 9);
            }

            return int.Parse(decimalPlacesString);
        }
    }
}
