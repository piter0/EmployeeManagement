namespace EmployeeManagement.Domain.ValueObjects
{
    public sealed class LastName
    {
        public string Value { get; }

        public LastName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Nazwisko nie może być puste.", nameof(value));

            }

            if (value.Length < 1 || value.Length > 50)
            {
                throw new ArgumentException("Nazwisko musi mieć długość 1-50 znaków.", nameof(value));

            }

            Value = value;
        }

        public override string ToString() => Value;
        public override bool Equals(object obj) => obj is LastName ln && ln.Value == Value;
        public override int GetHashCode() => Value.GetHashCode();
    }
}
