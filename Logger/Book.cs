using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public record Book(string Title, FullName Author, string ISBN) : Entity
    {
        // We are implicitly overriding the name attribute because there is only one object from which it 
        // Derrives so therefore adding it explicitly is unnecessarily verbose
        public override string Name { get => Title; }
       
    }
  
   
}
