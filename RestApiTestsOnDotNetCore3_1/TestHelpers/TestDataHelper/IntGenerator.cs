using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace RestApiTestsOnDotNetCore3_1.TestHelpers.TestDataHelper
{
    public static class IntGenerator
    {
        private static readonly Random Random = new Random();

        public static int GenerateRandomNumber(int length)
        {
            Assert.AreNotEqual(0, length);
            string numberAsString = null;
            for (var i = 0; i < length; i++)
            {
                numberAsString += GenerateRandomNumber(0, 9).ToString();
            }

            return int.Parse(numberAsString!);
        }

        public static int GenerateRandomNumber(int min, int max)
        {
            return Random.Next(min, max + 1);
        }

        public static int GenerateRandomNumber(int? min, int? max)
        {
            min.Should().NotBeNull();
            max.Should().NotBeNull();
            // ReSharper disable once PossibleInvalidOperationException
            return Random.Next(min.Value, 
                // ReSharper disable once PossibleInvalidOperationException
                max.Value + 1);
        }

        public static List<int> GenerateRandomNumbers(int min, int max, int recordsCount)
        {
            recordsCount.Should().BeGreaterThan(0);
            var randomNumbers = new List<int>();
            for (var i = 0; i < recordsCount; i++)
            {
                randomNumbers.Add(GenerateRandomNumber(min, max));
            }

            return randomNumbers;
        }
    }
}
