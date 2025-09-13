using EmployeeManagement.Domain.Enums;
using EmployeeManagement.Domain.Models;
using EmployeeManagement.Domain.ValueObjects;
using FluentAssertions;

namespace EmployeeManagement.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void Constructor_Should_Create_Employee_With_Valid_Data()
        {
            // arrange
            var id = Guid.NewGuid();
            var number = "00000001";
            var lastName = new LastName("Kowalski");
            var gender = Gender.Male;

            // act
            var emp = new Employee(id, number, lastName, gender);

            // assert
            emp.Id.Should().Be(id);
            emp.EmployeeNumber.Should().Be(number);
            emp.LastName.Should().Be(lastName);
            emp.Gender.Should().Be(gender);
        }

        [Fact]
        public void UpdateDetails_Should_Update_Properties()
        {
            // arrange
            var emp = new Employee(Guid.NewGuid(), "00000001", new LastName("Nowak"), Gender.Female);

            // act
            emp.UpdateDetails(new LastName("Kowalski"), Gender.Male);

            // assert
            emp.LastName.Value.Should().Be("Kowalski");
            emp.Gender.Should().Be(Gender.Male);
        }

        [Fact]
        public void Constructor_Should_Throw_On_Invalid_EmployeeNumber()
        {
            // arrange & act
            Action act = () => new Employee(Guid.NewGuid(), "123", new LastName("X"), Gender.Male);

            // assert
            act.Should().Throw<ArgumentException>();
        }
    }
}
