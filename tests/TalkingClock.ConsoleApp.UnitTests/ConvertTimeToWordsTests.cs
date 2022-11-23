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
    public void Should_return_human_friendly_time_now_with_meridiem()
    {
        var result = ConvertTimeToWords.ConvertDateTime();
        result.ShouldNotBeEmpty();
    }

    [Test]
    public void Should_return_human_friendly_time_with_meridiem()
    {
        var timeParam = "16:35";
        var result = ConvertTimeToWords.ConvertDateTime(timeParam, true);
        result.ShouldNotBeEmpty();
        result.ShouldBe("Twenty five to five PM");
    }

    [Test]
    public void Should_return_human_friendly_time_without_meridiem()
    {
        var timeParam = "16:30";
        var result = ConvertTimeToWords.ConvertDateTime(timeParam, false);
        result.ShouldNotBeEmpty();
        result.ShouldBe("Half past four");
    }

    [Test]
    public void Should_return_correct_time_output()
    {
        var timeParam = "16:30";
        var timeOutput = ConvertTimeToWords.ConvertDateTime(timeParam);
        var result = WriteTime.Run(timeOutput);
        result.ShouldNotBeEmpty();
        result.ShouldBe($"-----------------------\r\n{timeOutput}\r\n-----------------------\r\n");
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
    public void SpeakingClock_should_return_true_when_enabled()
    {
        var time = "16:30";
        var timeOutput = ConvertTimeToWords.ConvertDateTime(time, false);
        timeOutput.ShouldBe("Half past four");
        var result = SpeakingClock.Run(timeOutput, true);
        result.ShouldBeTrue();
    }

    [Test]
    public void SpeakingClock_should_return_false_when_not_enabled()
    {
        //var time = "16:30";
        //var timeOutput = ConvertTimeToWords.ConvertDateTime(time, false);
        var result = SpeakingClock.Run("", false);
        result.ShouldBeFalse();
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