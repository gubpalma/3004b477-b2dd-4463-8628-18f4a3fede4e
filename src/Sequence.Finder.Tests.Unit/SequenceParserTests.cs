using System;
using System.Collections.Generic;
using System.Linq;
using Sequence.Finder.Infrastructure;
using Xunit;

namespace Sequence.Finder.Tests.Unit
{
    public class SequenceParserTests
    {
        private readonly TestContext _context = new();

        [Theory]
        [InlineData(null)]
        [InlineData("14 19 10 49", 14, 19, 10, 49)]
        [InlineData("14 19  10 49 ", 14, 19, 10, 49)]
        [InlineData("123", 123)]
        public void Test_String_Parsing_Ok(string values, params int[] expected)
        {
            _context
                .ArrangeInputString(values);

            _context
                .ActPerformParse();

            _context
                .AssertExpectedValues(expected);
        }

        [Theory]
        [InlineData("93 39 j", SequenceParser.FormatErrorMessage)]
        [InlineData(" fff ", SequenceParser.FormatErrorMessage)]
        [InlineData("123 123 1234567890987654321234567890987654321", "Invalid input format (value '1234567890987654321234567890987654321', expected integer")]
        public void Test_String_Parsing_Exception(string values, string expectedMessage)
        {
            _context
                .ArrangeInputString(values);

            var ex =
                Assert
                    .ThrowsAny<Exception>(() => _context.ActPerformParse());

            Assert
                .Equal(ex.Message, expectedMessage);
        }

        private class TestContext
        {
            private readonly SequenceParser _sut = new();
            private string _value;
            private IEnumerable<int> _results;

            public void ArrangeInputString(string value) => _value = value;

            public void ActPerformParse() => 
                _results = 
                    _sut
                        .Perform(_value);

            public void AssertExpectedValues(params int[] expected)
            {
                Assert
                    .NotNull(_results);

                Assert
                    .Equal(expected.Length, _results.Count());

                for (var i=0; i < _results.Count(); i++)
                {
                    Assert
                        .Equal(_results.ElementAt(i), expected[i]);
                }
            }
        }
    }
}