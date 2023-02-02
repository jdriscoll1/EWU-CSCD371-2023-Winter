using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    /*
     * It is necessary to reference our variables via reference because there is a person whom exists elsewhere
     * who has this name, and we referencing that person
     * To store the variables by value may lead to data duplication incorrect data edits
     */


    // The type should be immutable because at no point do we want to reference a different person's full name
    public record FullName(in string FirstName, in string MiddleName, in string LastName); 
   
}
