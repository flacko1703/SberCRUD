namespace SberCrudOps.Infrastructure.EF.Models;

public class SberOperationReadModel
{
    public int Id { get; set; }
    public SberOperationInfoReadModel OperationInfo { get; set; }
    public TypeWorkReadModel TypeWork { get; set;}
    public bool IsCompleted { get; set; }
}