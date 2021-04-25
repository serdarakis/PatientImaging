
using System;
using System.Globalization;

namespace PatientImaging.Helpers
{
    public static class DatetimeExtensions
    {
        private const string Date_Format = "dd-MM-yyyy";
        public static DateTime ConvertToDatetimeOrThrow(this string data, string paramName, string format = null)
        {
            if (!DateTime.TryParseExact(data, format ?? Date_Format, new CultureInfo("en-US"), DateTimeStyles.None, out DateTime datetime))
                throw new ArgumentException("Datetime format is not valid", paramName);
            return datetime;
        }
    }
}
