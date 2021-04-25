
namespace PatientImaging.Helpers
{
    public static class StringExtensions
    {
        public static bool IsOnlyNumbers(this string value)
        {
            return char.IsDigit(value, 0);
        }
    }
}
