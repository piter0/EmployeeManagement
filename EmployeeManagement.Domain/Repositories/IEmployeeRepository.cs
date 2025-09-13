using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<string?> GetHighestEmployeeNumberAsync();
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
    }
}
