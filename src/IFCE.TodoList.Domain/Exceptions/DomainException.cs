using System.Collections.Generic;

namespace IFCE.TodoList.Domain.Exceptions
{
    public class DomainException : Exception
    {
        private readonly List<string> _errors = new();

        public IReadOnlyCollection<string> Errors => _errors;

        public DomainException()
        {
        }

        public DomainException(string message, List<string> errors) : base(message)
        {
            _errors = errors ?? new List<string>();
        }

        public DomainException(string message) : base(message)
        {
        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}