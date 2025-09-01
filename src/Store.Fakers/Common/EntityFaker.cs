using System;
using Bogus;
using Store.Domain.Common;

namespace Store.Fakers.Common;

public class EntityFaker<TEntity> : Faker<TEntity> where TEntity : Entity
{
    protected EntityFaker(string locale = "en") : base(locale)
    {
        int id = 1;
        RuleFor(e => e.Id, _ => id++);
    }

    public EntityFaker<TEntity> AsTransient()
    {
        RuleFor(e => e.Id, _ => default);
        return this;
    }
}
