using System;

namespace AbstractDependencies.Models;

public abstract class BaseEntityModel : IEntityModel
{
    public Guid Id { get; set; }
}
