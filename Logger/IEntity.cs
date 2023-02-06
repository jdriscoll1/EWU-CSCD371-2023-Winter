
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public interface IEntity
    {
        public Guid Id { get; init; }
        public string Name { get; }

    }

}
