﻿using System.Collections.Generic;

namespace Sequence.Finder.Interfaces
{
    public interface ISequenceFinder
    {
        IEnumerable<int> Perform(int[] values);
    }
}