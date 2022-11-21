// See https://aka.ms/new-console-template for more information

using System.Speech.Synthesis;
using TalkingClock.ConsoleApp;




var timeWords = DateTime.Now.ToShortTimeString();
if (args is { Length: > 0 })
{
   var isDateTime = DateTime.TryParse(args[0], out _);
  
   if (isDateTime)
   {
       timeWords = args[0];
   }
   else
   {
        Console.WriteLine($"{args[0]} is not a valid time format. Please try again.");
        return;
   }
}

var timeOutput = ConvertTimeToWords.ConvertDateTime(timeWords);
SpeechSynthesizer spokenTime = new();
spokenTime.Volume = 100;
spokenTime.Rate = 0;
spokenTime.Speak($"The time sponsored by Lloyds is {timeOutput}");

Console.WriteLine("The time sponsored by Lloyds is:\r\n-----------------------\r\n");
Console.WriteLine(timeOutput);
Console.WriteLine("\r\n-----------------------\r\n");
Console.WriteLine("Press any key to exit");
Console.ReadKey();
