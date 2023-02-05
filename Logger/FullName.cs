
﻿namespace Logger;

// Should we compare via value or reference type? Value Type.
// Why: This should be a record struct, that is a value type comparison,
// because it is possible that two people may share the same name
// If there exists two entites with the same name,
// and we want to validate that those two names are equal
// We should be using value equal, because reference comparison would need to validate
// that the two objects are tied to one object

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