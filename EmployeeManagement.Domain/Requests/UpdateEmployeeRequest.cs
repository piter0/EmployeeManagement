using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Domain.Requests
{
    public sealed record UpdateEmployeeRequest(Gender Gender, string LastName);
}
