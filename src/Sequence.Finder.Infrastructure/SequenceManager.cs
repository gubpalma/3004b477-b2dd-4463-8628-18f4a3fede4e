using Sequence.Finder.Contracts;
using Sequence.Finder.Interfaces;

namespace Sequence.Finder.Infrastructure
{
    public class SequenceManager : ISequenceManager
    {
        private readonly ISequenceParser _sequenceParser;
        private readonly ISequenceFinder _sequenceFinder;

        public SequenceManager(
            ISequenceParser sequenceParser, 
            ISequenceFinder sequenceFinder)
        {
            _sequenceParser = sequenceParser;
            _sequenceFinder = sequenceFinder;
        }

        public SequenceResponse Handle(SequenceRequest request)
        {
            var parsedData =
                _sequenceParser
                    .Perform(request.Data);

            var result =
                _sequenceFinder
                    .Perform(parsedData);

            return new
                SequenceResponse
                {
                    Result = string.Join(' ', result)
                };
        }
    }
}
