using System;

namespace CodeRedLauncher.Architecture
{
    // Stores minimum and maximum values as well as comparing given integers.
    public class RangeBase<T>
    {
        public T Minimum { get; set; }
        public T Maximum { get; set; }

        public RangeBase(T minimum, T maximum)
        {
            SetRange(minimum, maximum);
        }

        public void SetRange(T minimum, T maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }
    }

    public class Range32 : RangeBase<Int32>
    {
        public Range32(Int32 minimum, Int32 maximum) : base(minimum, maximum) { }

        public bool IsInRange(Int32 value)
        {
            if (value < Minimum || value > Maximum)
            {
                return false;
            }

            return true;
        }
    }

    public class Range64 : RangeBase<Int64>
    {
        public Range64(Int64 minimum, Int64 maximum) : base(minimum, maximum) { }

        public bool IsInRange(Int64 value)
        {
            if (value < Minimum || value > Maximum)
            {
                return false;
            }

            return true;
        }
    }

    public class RangeFloat : RangeBase<float>
    {
        public RangeFloat(float minimum, float maximum) : base(minimum, maximum) { }

        public bool IsInRange(float value)
        {
            if (value < Minimum || value > Maximum)
            {
                return false;
            }

            return true;
        }
    }

    public class RangeDecimal : RangeBase<decimal>
    {
        public RangeDecimal(decimal minimum, decimal maximum) : base(minimum, maximum) { }

        public bool IsInRange(decimal value)
        {
            if (value < Minimum || value > Maximum)
            {
                return false;
            }

            return true;
        }
    }
}
