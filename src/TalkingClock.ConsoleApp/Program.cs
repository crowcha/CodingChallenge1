// See https://aka.ms/new-console-template for more information


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
        Console.WriteLine($"{args[0]} is not a valid time format. Please try again using format HH:mm eg 16:30.");
        return;
   }
}

var timeOutput = ConvertTimeToWords.ConvertDateTime(timeWords);

Console.WriteLine("-----------------------\r\n");
Console.WriteLine(timeOutput);
Console.WriteLine("\r\n-----------------------\r\n");
Console.WriteLine("Press any key to exit");
Console.ReadKey();
