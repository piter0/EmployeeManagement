using EmployeeManagement.Domain.Enums;
using EmployeeManagement.Domain.Models;
using EmployeeManagement.Domain.Repositories;
using EmployeeManagement.Domain.Services;
using EmployeeManagement.Domain.ValueObjects;
using MediatR;

namespace EmployeeManagement.Domain.Handlers
{
    public sealed record CreateEmployeeCommand(Gender Gender, string LastName) : IRequest<Employee> { }

    public sealed class CreateEmployeeHandler(IEmployeeRepository repository,
        INextEmployeeNumberGenerator numberGenerator) : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        private readonly INextEmployeeNumberGenerator _numberGenerator = numberGenerator ?? throw new ArgumentNullException(nameof(numberGenerator));

        public async Task<Employee> Handle(CreateEmployeeCommand cmd, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(cmd);

            var lastNameVo = new LastName(cmd.LastName);
            var nextNumber = await _numberGenerator.GetNextAsync();

            var employee = new Employee(Guid.NewGuid(), nextNumber, lastNameVo, cmd.Gender);

            await _repository.AddAsync(employee);

            return employee;
        }
    }
}
