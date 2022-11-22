using TalkingClock.ConsoleApp.Extensions;

namespace TalkingClock.ConsoleApp;

public static class ConvertTimeToWords
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

    public static string ConvertDateTime(string shortDateTime="", bool addMeridiem = true)
    {
        if (shortDateTime == "") shortDateTime = DateTime.Now.ToShortTimeString();
        //Convert 24 hour clock to 12 hour and extract AM/PM
        string? time12;
        try
        {
            time12 = shortDateTime.ConvertFromToTime("HH:mm", "h:mm:tt");
        }
        catch (Exception ex)
        {
            if(ex is System.FormatException)  throw new System.FormatException($"{ex.Message} Please enter time in format HH:mm e.g 16:30");
            throw;
        }

        var time = time12.Split(":");
        Int32.TryParse(time[0], out var hours);
        Int32.TryParse(time[1], out var minutes);
        var meridiem = addMeridiem ? $" {time[2]}" : "";
        var minute = string.Empty;
        var hour = HourArray[hours];

        if (minutes < 1)
            return $"{hour} o'clock {meridiem}";
        else if (minutes == 15)
            return $"Quarter past {hour.ToLower()}{meridiem}";
        else if (minutes == 30)
            return $"Half past {hour.ToLower()}{meridiem}";
        else if (minutes == 45)
            return $"Quarter to {hour.ToLower()}{meridiem}";
        else if (minutes is >= 1 and < 30)
        {
            minute =  MinuteArray[minutes];
            return $"{minute} past {hour.ToLower()}{meridiem}";
        }
        else //minutes > 30 and !45
        {
            var intMinute =  60 - minutes;
            minute = MinuteArray[intMinute];
            return $"{minute} to {hour.ToLower()}{meridiem}";
        }

    }
}