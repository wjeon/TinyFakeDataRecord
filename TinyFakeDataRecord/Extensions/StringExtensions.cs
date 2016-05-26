using System.Globalization;

namespace TinyFakeDataRecord.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEqualTo(this string left, string right)
        {
            return 0 == CultureInfo.CurrentCulture.CompareInfo.Compare(left, right, CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth | CompareOptions.IgnoreCase);
        }
    }
}
