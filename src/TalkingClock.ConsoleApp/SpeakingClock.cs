using System.Runtime.InteropServices;
using System.Speech.Synthesis;

namespace TalkingClock.ConsoleApp;

public static class SpeakingClock
{
    public static bool Run(string timeOutput, bool isSpeechEnabled=false)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || !isSpeechEnabled) return false;
        SpeechSynthesizer spokenTime = new();
        spokenTime.Volume = 100;
        spokenTime.Rate = 0;
        spokenTime.Speak($"The time sponsored by Lloyds is {timeOutput}");
        return true;
    }
}