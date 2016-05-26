using System;

namespace TinyFakeDataRecord.Tests.Unit.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsEqualTo(this object left, object right)
        {
            if (left is int)
                return (int)left == (int)right;

            if (left is long)
                return (long)left == (long)right;

            if (left is double)
                return (double)left == (double)right;

            if (left is DateTime)
                return (DateTime)left == (DateTime)right;

            if (left is string)
                return left.ToString() == right.ToString();

            throw new NotSupportedException(string.Format("Type '{0}' is not supported for IsEqualTo operation", left.GetType().Name));
        }
    }
}
