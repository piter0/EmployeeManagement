using EmployeeManagement.Domain.Enums;
using EmployeeManagement.Domain.Handlers;
using EmployeeManagement.Domain.Models;
using EmployeeManagement.Domain.Repositories;
using EmployeeManagement.Domain.Services;
using FluentAssertions;
using Moq;

namespace EmployeeManagement.Tests
{
    public class CreateEmployeeHandlerTests
    {
        [Fact]
        public async Task HandleAsync_Should_Create_Employee_And_Call_Repository_Add()
        {
            // arrange
            var repoMock = new Mock<IEmployeeRepository>();
            repoMock.Setup(r => r.GetHighestEmployeeNumberAsync()).ReturnsAsync((string?)null);

            repoMock.Setup(r => r.AddAsync(It.IsAny<Employee>())).Returns(Task.CompletedTask);

            var generator = new NextEmployeeNumberGenerator(repoMock.Object);
            var handler = new CreateEmployeeHandler(repoMock.Object, generator);

            var cmd = new CreateEmployeeCommand(Gender.Male, "Kowalski");

            // act
            var created = await handler.Handle(cmd, CancellationToken.None);

            // assert
            created.EmployeeNumber.Should().Be("00000001");
            created.LastName.Value.Should().Be("Kowalski");
            repoMock.Verify(r => r.AddAsync(It.Is<Employee>(e => e.EmployeeNumber == "00000001")), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_Should_Increment_Number_Based_On_Highest()
        {
            // arrange
            var repoMock = new Mock<IEmployeeRepository>();
            repoMock.Setup(r => r.GetHighestEmployeeNumberAsync()).ReturnsAsync("00000009");
            repoMock.Setup(r => r.AddAsync(It.IsAny<Employee>())).Returns(Task.CompletedTask).Verifiable();

            var generator = new NextEmployeeNumberGenerator(repoMock.Object);
            var handler = new CreateEmployeeHandler(repoMock.Object, generator);

            var cmd = new CreateEmployeeCommand(Gender.Female, "Nowak");

            // act
            var created = await handler.Handle(cmd, CancellationToken.None);

            //assert
            created.EmployeeNumber.Should().Be("00000010");
            repoMock.Verify(r => r.AddAsync(It.Is<Employee>(e => e.EmployeeNumber == "00000010")), Times.Once);
        }
    }
}
