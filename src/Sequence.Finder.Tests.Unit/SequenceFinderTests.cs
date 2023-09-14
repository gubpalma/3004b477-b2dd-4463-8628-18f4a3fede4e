using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Sequence.Finder.Infrastructure;
using Xunit;

namespace Sequence.Finder.Tests.Unit
{
    public class SequenceFinderTests
    {
        private readonly TestContext _context = new();

        [Theory]
        [InlineData("TEST_CASE_1", "1 5 9")]
        [InlineData("TEST_CASE_2", "1710 2461 9288 10195 10431 12485")]
        [InlineData("TEST_CASE_3", "10298 10897 12291 15037 18446 23435 25333 27266")]
        [InlineData("TEST_CASE_4", "3862 16353 22813 28735")]
        [InlineData("TEST_CASE_5", "11084 11970 24975 30922")]
        [InlineData("TEST_CASE_6", "3808 3908 10386 19306")]
        [InlineData("TEST_CASE_7", "125 1841 5882 18464 28317 31497")]
        [InlineData("TEST_CASE_8", "9139 17687 25106 26202 27592 30937")]
        [InlineData("TEST_CASE_9", "918 1089 5133 7725 18035 24605 26716 27095")]
        [InlineData("TEST_CASE_10", "2 4 6")]
        [InlineData("TEST_CASE_11", "1 5 9")]
        public void Test_Sequence_Finding_Ok(string testFile, string expectedResult)
        {
            _context
                .ArrangeTestFileData(testFile);

            _context
                .ActPerformFind();

            _context
                .AssertExpectedValues(expectedResult);
        }

        private class TestContext
        {
            private readonly SequenceFinder _sut = new();
            private IEnumerable<int> _values;
            private IEnumerable<int> _results;

            public void ArrangeTestFileData(string testFile)
            {
                var currentPath = 
                    Path
                        .GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                var fileData = 
                    File
                        .ReadAllText($"{currentPath}//Resource//{testFile}.txt");
                
                var results = 
                    fileData
                        .Split(' ',
                    StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                var values = new List<int>();

                foreach (var result in results)
                {
                    values.Add(int.Parse(result));
                }

                _values = values;
            }

            public void ActPerformFind() =>
                _results =
                    _sut
                        .Perform(_values);

            public void AssertExpectedValues(string expectedResult)
            {
                Assert
                    .NotNull(_results);

                var formattedResult =
                    string
                        .Join(' ', _results);

                Assert
                    .Equal(formattedResult, expectedResult);
            }
        }
    }
}