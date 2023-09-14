using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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