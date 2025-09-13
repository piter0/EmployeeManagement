using EmployeeManagement.Domain.Repositories;

namespace EmployeeManagement.Domain.Services
{
    public class NextEmployeeNumberGenerator : INextEmployeeNumberGenerator
    {
        private readonly IEmployeeRepository _repository;
        public NextEmployeeNumberGenerator(IEmployeeRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<string> GetNextAsync()
        {
            var highest = await _repository.GetHighestEmployeeNumberAsync();
            var nextNumeric = 1;
            if (!string.IsNullOrEmpty(highest))
            {
                if (!int.TryParse(highest, out var currentNumeric))
                {
                    throw new InvalidOperationException("Nieprawidłowy format numeru ewidencyjnego w repozytorium.");
                }

                nextNumeric = currentNumeric + 1;
            }

            if (nextNumeric > 99999999)
            {
                throw new InvalidOperationException("Przekroczono maksymalny możliwy numer ewidencyjny.");
            }

            return nextNumeric.ToString("D8");
        }
    }
}
