using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    /* VALUE OR REFERENCE TYPE EXPLANIATION: */
    // Should we compare via value or reference type? Value Type.
    // Why: This should be a record struct, that is a value type comparison,
    // because it is possible that two people may share the same name
    // If there exists two entites with the same name,
    // and we want to validate that those two names are equal
    // We should be using value equal, because reference comparison would need to validate
    // that the two objects are tied to one object

    /* MUTABLE OR IMMUTABLE EXPLANATION:  */
    // Should the full name structure be mutable or immuable? Immutable
    // There are three reasons that the Full Name record should be immutable
    // Firstly, whenever we change the name, we should be creating a new Full Name Object rather than changing
    // a previous one for better clarity
    // Secondly, it should be immuatable so that it does not change a different object elsewhere in the code
    // Thirdly, hash codes are calculated from the direct data storage, if we chagne the hash code we could lose information
    public readonly record struct FullName(string FirstName, string LastName, string? MiddleName = null)
    {
        public string FirstName { get; } = FirstName ?? throw new ArgumentNullException(nameof(FirstName));
        public string LastName { get; } = LastName ?? throw new ArgumentNullException(nameof(LastName));
        public string? MiddleName { get; } = MiddleName;
    }

    public record Person(FullName FullName) : Entity
    {
        // We are implicitly overriding the name attribute because there is only one object from which it 
        // Derrives so therefore adding it explicitly is unnecessarily verbose
        public override string Name { get => FullName.ToString(); }
    }

    public record Book(string Title, FullName Author, string ISBN) : Entity
    {
        // We are implicitly overriding the name attribute because there is only one object from which it 
        // Derrives so therefore adding it explicitly is unnecessarily verbose
        public override string Name { get => Title; }

    }

    public record Employee(FullName FullName, string PositionTitle, string Company) : Person(FullName);

   

    public record Student(FullName FullName, string Degree, string SchoolName) : Person(FullName);
}
