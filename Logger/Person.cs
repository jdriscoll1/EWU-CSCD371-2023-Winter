using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public record Person(FullName FullName) : Entity
    {
        public override string Name { get => FullName.ToString(); }
    }
}
