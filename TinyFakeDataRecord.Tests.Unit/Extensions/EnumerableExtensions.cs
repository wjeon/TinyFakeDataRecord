using System.Collections.Generic;

namespace TinyFakeDataRecord.Tests.Unit.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsSequenceObjectEqualTo(this List<object[]> left, List<object[]> right)
        {
            if (left == null && right == null)
                return true;

            if (left.Count != right.Count)
                return false;

            for (var i = 0; i < left.Count; i++ )
            {
                if (left[i].Length != right[i].Length)
                    return false;

                for (var j = 0; j < left[i].Length; j++)
                {
                    if (!left[i][j].IsEqualTo(right[i][j]))
                            return false;
                }
            }

            return true;
        }
    }
}
