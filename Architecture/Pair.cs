using System;

namespace CodeRedLauncher
{
    // A user-modifiable version of tuples, similar to "std::pair"
    public class Pair<T1, T2>
    {
        public T1 First { get; set; }
        public T2 Second { get; set; }

        public Pair(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }

        // Swaps the current classes pair values with another pairs values.
        public void Swap(ref Pair<T1, T2> other)
        {
            T1 firstCopy = First;
            T2 secondCopy = Second;
            First = other.First;
            Second = other.Second;
            other.First = firstCopy;
            other.Second = secondCopy;
        }
    }
}
