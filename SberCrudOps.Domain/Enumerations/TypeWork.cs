using SberCrudOps.Domain.SeedWork;

namespace SberCrudOps.Domain.Enumerations;

/// <summary>
/// "Smart enum" for TypeWork
/// </summary>
public sealed record TypeWork : Enumeration<TypeWork>
{
    /// <summary>
    /// Create operation
    /// </summary>
    public static TypeWork Create = new(1, nameof(Create));
    
    /// <summary>
    /// Add operation
    /// </summary>
    public static TypeWork Update = new(2, nameof(Update));
    
    /// <summary>
    /// Delete operation
    /// </summary>
    public static TypeWork Delete = new(3, nameof(Delete));

    private TypeWork(int value, string displayName) 
        : base(value, displayName)
    {
    }
}