using EmployeeManagement.Domain.ValueObjects;
using FluentAssertions;

namespace EmployeeManagement.Tests
{
    public class LastNameTests
    {
        [Theory]
        [InlineData("A")]
        [InlineData("Nowak")]
        [InlineData("ANameThatIsExactlyFiftyCharactersLong000000000")]
        public void Constructor_Should_Create_For_Valid_Input(string value)
        {
            // arrange & act
            var ln = new LastName(value);

            // assert
            ln.Value.Should().Be(value);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_Should_Throw_For_Invalid_Input(string value)
        {
            // arrange & act
            Action act = () => new LastName(value);

            // assert
            act.Should().Throw<ArgumentException>();
        }
    }
}
