using Shouldly;
using TalkingClock.ConsoleApp;

namespace TalkingClock.ConsoleApp.UnitTests;

public class ConvertTimeToWordsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Should_return_human_friendly_time()
    {
        var timeParam = "16:30";
        var result = ConvertTimeToWords.ConvertDateTime(timeParam);
        result.ShouldNotBeEmpty();
        result.ShouldBe("Half past four PM");
    }

    [Test]
    public void Should_throw_FormatException_with_invalid_param()
    {
        var timeParam = "1345";
        var ex = Should.Throw<FormatException>(() => ConvertTimeToWords.ConvertDateTime(timeParam));
        ex.Message.ShouldBe($"String '{timeParam}' was not recognized as a valid DateTime. Please enter time in format HH:mm e.g 16:30");
    }

    [Test]
    public void Should_throw_FormatException_with_Unsupported_Param()
    {
        var timeParam = "24:63";
        var ex = Should.Throw<FormatException>(() => ConvertTimeToWords.ConvertDateTime(timeParam));
        ex.Message.ShouldContain($"Please enter time in format HH:mm e.g 16:30");
    }

    [Test]
    public void Should_Return_Correctly_For_All_Valid_Times()
    {
        for (var h = 0; h < 24; h++)
        {
            for(var m = 0; m < 60; m++)
            {
                string hour = h.ToString();
                string minute = m.ToString();
                if (h < 10)  hour = $"0{h}";
                if (m < 10) minute = $"0{m}";
                
                Should.NotThrow(() => ConvertTimeToWords.ConvertDateTime($"{hour}:{minute}"));
                //Use return below to see all times in test window
                Console.WriteLine(ConvertTimeToWords.ConvertDateTime($"{hour}:{minute}"));
            }
        }
    }
}