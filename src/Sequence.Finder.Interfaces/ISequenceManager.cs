using Sequence.Finder.Contracts;

namespace Sequence.Finder.Interfaces
{
    public interface ISequenceManager
    {
        SequenceResponse Handle(SequenceRequest request);
    }
}
