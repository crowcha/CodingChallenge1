using System.Runtime.InteropServices;
using System.Speech.Synthesis;

namespace TalkingClock.ConsoleApp;

public static class SpeakingClock
{
    public static void Run(string timeOutput)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return;
        SpeechSynthesizer spokenTime = new();
        spokenTime.Volume = 100;
        spokenTime.Rate = 0;
        spokenTime.Speak($"The time sponsored by Lloyds is {timeOutput}");
    }
}