using Sequence.Finder.Interfaces;

namespace Sequence.Finder.Infrastructure
{
    public class SequenceFinder : ISequenceFinder
    {
        public IEnumerable<int> Perform(int[] values)
        {
            var lastKnownLongest = Array.Empty<int>();

            if (values == null)
                return
                    lastKnownLongest;

            var currentSequence = new List<int>();

            for (var i = 0; i < values.Count(); i++)
            {
                if (i == 0) 
                    continue;

                if (values[i] > values[i - 1])
                {
                    currentSequence
                        .Add(values[i]);

                    if (currentSequence.Count > lastKnownLongest.Length)
                        lastKnownLongest = currentSequence.ToArray();
                }
                else
                {
                    currentSequence
                        .Clear();
                }
            }

            return lastKnownLongest;
        }
    }
}