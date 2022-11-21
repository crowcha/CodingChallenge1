using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;


namespace TalkingClock.ConsoleApp.Extensions;

internal static class DateTimeExtensions
{
    /// <summary>
    /// Converts times from 24 to 12 and vice versa
    /// </summary>
    /// <code>
    /// var time24 = 13:15
    /// var time12 = 01:15 PM
    /// var convertedTo12 = time24.ConvertFromToTime( "HH:mm", "h:mm");
    /// var convertedTo24 = time12.ConvertFromToTime("h:mm tt", "HH:mm");
    /// </code>
    public static string ConvertFromToTime(this string timeHour, string inputFormat, string outputFormat)
    {
        var timeFromInput = DateTime.ParseExact(timeHour, inputFormat, null, DateTimeStyles.None);
        string timeOutput = timeFromInput.ToString(
            outputFormat,
            CultureInfo.InvariantCulture);
        return timeOutput;
    }
}