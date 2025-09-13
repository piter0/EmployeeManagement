using EmployeeManagement.Domain.Enums;
using EmployeeManagement.Domain.ValueObjects;

namespace EmployeeManagement.Domain.Models
{
    public class Employee
    {
        public Guid Id { get; private set; }
        public string EmployeeNumber { get; private set; }
        public LastName LastName { get; private set; }
        public Gender Gender { get; private set; }

        public Employee(Guid id, string employeeNumber, LastName lastName, Gender gender)
        {
            Id = id == Guid.Empty ? throw new ArgumentException("Id nie może być pusty.", nameof(id)) : id;

            if (string.IsNullOrWhiteSpace(employeeNumber))
            {
                throw new ArgumentException("Numer ewidencyjny jest wymagany.", nameof(employeeNumber));

            }

            if (employeeNumber.Length != 8)
            {
                throw new ArgumentException("Numer ewidencyjny musi mieć 8 znaków.", nameof(employeeNumber));
            }

            EmployeeNumber = employeeNumber;
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Gender = gender;
        }

        public void UpdateDetails(LastName lastName, Gender gender)
        {
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Gender = gender;
        }
    }
}
