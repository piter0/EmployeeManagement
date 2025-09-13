namespace EmployeeManagement.Domain.Services
{
    public interface INextEmployeeNumberGenerator
    {
        Task<string> GetNextAsync();
    }
}
