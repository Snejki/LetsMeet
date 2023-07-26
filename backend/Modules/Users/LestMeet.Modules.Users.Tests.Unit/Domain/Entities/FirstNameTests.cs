using FluentAssertions;
using LetsMeet.Modules.Users.Domain.Entities;
using LetsMeet.Modules.Users.Domain.Exceptions;
using Xunit;

namespace LestMeet.Modules.Users.Tests.Unit.Domain.Entities;

public sealed class FirstNameTests
{
    [Theory]
    [InlineData("Tomasz")]
    [InlineData("Tomaszek Amadeusz")]
    [InlineData("Żaneta")]
    [InlineData(" George ")]
    [InlineData("Dartag'nan")]
    public void FirstName_WhenProvidedCorrectData_Should_Be_Created(string value)
    {
        var sut = FirstName.Create(value);

        sut.Value.Should().BeEquivalentTo(value);
    }
    
    
    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(null)]
    public void FirstName_WhenProvidedWrongData_Should_Throw(string value)
    {
        var exception = Record.Exception(() => FirstName.Create(value));

        exception.Should().BeOfType<FirstNameCaNotBeEmpty>();
    }
}