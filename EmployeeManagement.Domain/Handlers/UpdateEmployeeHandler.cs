using EmployeeManagement.Domain.Enums;
using EmployeeManagement.Domain.Repositories;
using MediatR;

namespace EmployeeManagement.Domain.Handlers
{
    public sealed record UpdateEmployeeCommand(Guid Id, Gender Gender, string LastName) : IRequest { }

    public sealed class UpdateEmployeeHandler(IEmployeeRepository repository) : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IEmployeeRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public Task Handle(UpdateEmployeeCommand cmd, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(cmd);

            // No need for implementation

            return Task.CompletedTask;
        }
    }
}
