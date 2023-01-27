using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: CLSCompliant(true)]
namespace CanHazFunny
{
    public interface IJokeService
    {
        public string GetJoke(); 
    }
}
