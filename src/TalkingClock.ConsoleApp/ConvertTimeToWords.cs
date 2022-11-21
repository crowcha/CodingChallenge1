using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalkingClock.ConsoleApp.Extensions;

namespace TalkingClock.ConsoleApp;

internal static class ConvertTimeToWords
{
    private static readonly string[] HourArray =
        { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve" };

    private static readonly string[] MinuteArray =
    {
       "", "One","Two","Three","Four","Five","Six","Seven","Eight","Nine","Ten","Eleven","Twelve",
        "Thirteen","Fourteen","Fifteen","Sixteen","Seventeen","Eighteen","Nineteen","Twenty","Twenty one",
        "Twenty two","Twenty three","Twenty four","Twenty five","Twenty six","Twenty seven","Twenty eight",
        "Twenty nine","Thirty"
    };

    internal static string ConvertDateTime(string shortDateTime)
    {
        //Convert 24 hour clock to 12 hour and extract AM/PM
        var time12 = shortDateTime.ConvertFromToTime("HH:mm", "h:mm:tt");

        var time = time12.Split(":");
        Int32.TryParse(time[0], out var hours);
        Int32.TryParse(time[1], out var minutes);
        var ampm = time[2];
        var minute = string.Empty;
        var hour = HourArray[hours];

        if (minutes < 1)
            return $"{hour} o'clock {ampm}";
        else if (minutes == 15)
            return $"Quarter past {hour.ToLower()} {ampm}";
        else if (minutes == 30)
            return $"Half past {hour.ToLower()} {ampm}";
        else if (minutes == 45)
            return $"Quarter to {hour.ToLower()} {ampm}";
        else if (minutes is >= 1 and < 30)
        {
            minute =  MinuteArray[minutes];
            return $"{minute} past {hour.ToLower()} {ampm}";
        }
        else //minutes > 30 and !45
        {
            var intMinute =  60 - minutes;
            minute = MinuteArray[intMinute];
            return $"{minute} to {hour.ToLower()} {ampm}";
        }

    }
}