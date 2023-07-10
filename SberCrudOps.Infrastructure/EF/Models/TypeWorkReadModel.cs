namespace SberCrudOps.Infrastructure.EF.Models;

public class TypeWorkReadModel
{
    public int Value { get; set; }
    public string Name { get; set; }

    public static TypeWorkReadModel Create(int value, string name)
    {
        return new TypeWorkReadModel();
    }
}