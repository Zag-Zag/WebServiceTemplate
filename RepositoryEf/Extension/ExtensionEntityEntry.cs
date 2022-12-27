using AbstractDependencies.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataBaseEf.Extension;

internal static class ExtensionEntityEntry
{
    internal static EntityEntry<TEntity> AddIgnoreProps<TEntity>(this EntityEntry<TEntity> entityEntry, IEnumerable<Expression<Func<TEntity, object>>> ignores)
        where TEntity: BaseEntityModel
    {
        foreach(var ignore in ignores)
        {
            entityEntry.Property(ignore).IsModified = false;
        }
        return entityEntry;
    }
}
