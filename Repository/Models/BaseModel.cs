using AbstractDependencies.Models;

namespace Repository.Model;

public class BaseModel : IBusinessModel
{
    public Guid Id { get; set; } 
}
