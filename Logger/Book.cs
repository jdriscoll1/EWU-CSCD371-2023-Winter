using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public record Book(string title, string author, string isbn) : IEntity
    {
        public Guid Id { init; get; }
        private string? _Name; 
        public string Name { 
            get {
                return _Name!; 
            }
            set {
                _Name = value ?? throw new ArgumentNullException(nameof(value));
            }
        }
    }
    public record Student(FullName fullName, long studentID) : IEntity {
        public Guid Id { init; get; }
        private string? _Name;
        public string Name
        {
            get
            {
                return _Name!;
            }
            set
            {
                _Name = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

    }
    public record Employee(FullName fullName, long employeeID) : IEntity {
        public Guid Id { init; get; }
        private string? _Name;
        public string Name
        {
            get
            {
                return _Name!;
            }
            set
            {
                _Name = value ?? throw new ArgumentNullException(nameof(value));
            }
        }
    }
}
