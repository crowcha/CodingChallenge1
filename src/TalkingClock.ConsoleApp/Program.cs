// See https://aka.ms/new-console-template for more information


using Microsoft.Extensions.Configuration;
using TalkingClock.ConsoleApp;

var configuration = new ConfigurationBuilder().AddJsonFile(($"appsettings.json"));
var config = configuration.Build();
var isSpeechEnabled = config.GetSection("SpeechEnabled").Value == "True";
var addMeridiem = config.GetSection("AddMeridiem").Value == "True";

string timeOutput;

try
{
    timeOutput = ConvertTimeToWords.ConvertDateTime(args is { Length: > 0 } ? args[0] : "", addMeridiem);
}
catch (FormatException ex)
{
    isSpeechEnabled = false;
    timeOutput = ex.Message;
}

Console.WriteLine(WriteTime.Run(timeOutput));

if (isSpeechEnabled) SpeakingClock.Run(timeOutput);


Console.WriteLine("Press any key to exit");
Console.ReadKey();
