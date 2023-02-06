using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
 public abstract record class Entity : IEntity
    {
        // We want to implictly implement the IEntity class because we only have one interface we're implementing
        // It is unnecessary to declare which Interface is being overridden when there is only interface to override 

        public Guid Id { init; get; } = Guid.NewGuid();

        public abstract string Name { get; }

    }
}
