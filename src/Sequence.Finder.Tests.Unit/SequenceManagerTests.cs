using System;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using Sequence.Finder.Contracts;
using Sequence.Finder.Infrastructure;
using Sequence.Finder.Interfaces;
using Xunit;

namespace Sequence.Finder.Tests.Unit
{
    public class SequenceManagerTests
    {
        private readonly TestContext _context = new();

        [Fact]
        public void Test_Valid_Request()
        {
            _context.ArrangeParsingSuccess();
            _context.ActRunHandleMessage();
            _context.AssertFinderWasCalled();
        }

        [Fact]
        public void Test_Invalid_Request()
        {
            _context.ArrangeParsingError();
            Assert.Throws<Exception>(() => _context.ActRunHandleMessage());
            _context.AssertFinderWasNotCalled();
        }

        private class TestContext
        {
            private readonly IFixture _fixture;
            private readonly SequenceManager _sut;
            private readonly Mock<ISequenceParser> _sequenceParser;
            private readonly Mock<ISequenceFinder> _sequenceFinder;
            private readonly SequenceRequest _request;

            public TestContext()
            {
                _fixture = new Fixture().Customize(new AutoMoqCustomization());

                _sequenceParser = new Mock<ISequenceParser>();
                _sequenceFinder = new Mock<ISequenceFinder>();

                _sut =
                    new SequenceManager(
                        _sequenceParser.Object,
                        _sequenceFinder.Object);

                _request = new SequenceRequest();
            }

            public void ArrangeParsingSuccess()
            {
                _sequenceParser
                    .Setup(o => o.Perform(It.IsAny<string>()))
                    .Returns(
                        _fixture
                            .CreateMany<int>(5)
                            .ToArray());
            }

            public void ArrangeParsingError()
            {
                _sequenceParser
                    .Setup(o => o.Perform(It.IsAny<string>()))
                    .Throws(new Exception("There was an error"));
            }

            public void ActRunHandleMessage()
            {
                _sut
                    .Handle(_request);
            }

            public void AssertFinderWasCalled()
            {
                _sequenceParser
                    .Verify(o => o.Perform(It.IsAny<string>()), Times.Once);

                _sequenceFinder
                    .Verify(o => o.Perform(It.IsAny<int[]>()), Times.Once);
            }

            public void AssertFinderWasNotCalled()
            {
                _sequenceParser
                    .Verify(o => o.Perform(It.IsAny<string>()), Times.Once);

                _sequenceFinder
                    .Verify(o => o.Perform(It.IsAny<int[]>()), Times.Never);
            }
        }
    }
}
