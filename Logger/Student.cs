using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public record Student(FullName FullName, long StudentID)
    {
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
