using System.Collections.Generic;

namespace Sequence.Finder.Interfaces
{
    public interface ISequenceParser
    {
        IEnumerable<int> Perform(string values);
    }
}