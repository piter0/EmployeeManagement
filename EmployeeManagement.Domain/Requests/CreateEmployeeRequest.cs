using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Domain.Requests
{
    public sealed record CreateEmployeeRequest(Gender Gender, string LastName);
}
