using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;

namespace RestApiTestsOnDotNetCore3_1.TestHelpers.TestDataHelper
{
    public static class StringGenerator
    {
        private static readonly Random Random = new Random();

        /// <summary>
        /// Generates specified size random string in Upper or lower case
        /// </summary>
        /// <param name="size">number of chars</param>
        /// <param name="lowerCase">Defines lower or upper(default) case chars register</param>
        /// <returns></returns>
        public static string GenerateRandomString(int size, bool lowerCase = false)
        {
            if (size.Equals(0))
                return string.Empty;
            var builder = new StringBuilder(size);
            // char is a single Unicode character  
            var offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)Random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }
            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        /// <summary>
        /// Generates number of Random string of the specified size
        /// </summary>
        /// <param name="eachStringSize"></param>
        /// <param name="stringsCount"></param>
        /// <param name="lowerCase"></param>
        /// <returns></returns>
        public static List<string> GenerateRandomStrings(int eachStringSize, int stringsCount, bool lowerCase = false)
        {
            stringsCount.Should().BeGreaterThan(0);
            var listOfWords = new List<string>();
            for (var i = 0; i < stringsCount; i++)
            {
                listOfWords.Add(GenerateRandomString(eachStringSize, lowerCase));
            }

            return listOfWords;
        }

        public static string GenerateRandomString(int size, int whiteSpaceAfterNumberOfChars, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);
            // char is a single Unicode character  
            var offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26
            var currentChar = 0;

            for (var i = 0; i < size; i++)
            {
                if (whiteSpaceAfterNumberOfChars > 0 && currentChar == whiteSpaceAfterNumberOfChars)
                {
                    builder.Append(" ");
                    currentChar = 0;
                }
                else
                {
                    var @char = (char)Random.Next(offset, offset + lettersOffset);
                    builder.Append(@char);
                }

                currentChar++;
            }
            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        public static string GenerateStringWithRandomSpecialChars()
        {
            var specialChars = new List<string>
            {
                ",", ".", "/", ";", ":", "-", "_", "+",
                "(", ")", "*", "&", "^", "%", "$", "#",
                "@", "'"
            };

            return GenerateRandomStringBasedOnListOfChars(specialChars);
        }

        public static string GenerateRandomStringBasedOnListOfChars(List<string> possibleChars)
        {
            var stringWithSpecialChars = string.Empty;
            var random = new Random();

            int turnsCount = possibleChars.Count;

            for (int i = 0; i < turnsCount; i++)
            {
                int index = random.Next(possibleChars.Count);
                stringWithSpecialChars += possibleChars[index];
                possibleChars.RemoveAt(index);
            }

            return stringWithSpecialChars;
        }

        public static string GenerateRandomStringBasedOnListOfChars(string possibleChars)
        {
            List<string> listOfChars = possibleChars.ToCharArray().Select(c => c.ToString()).ToList();
            return GenerateRandomStringBasedOnListOfChars(listOfChars);
        }
    }
}
