﻿using OData.QueryBuilder.Builders.Nested;
using System;
using System.Linq.Expressions;

namespace OData.QueryBuilder.Parameters.Nested
{
    public interface IODataQueryNestedParameter<TEntity>
    {
        IODataQueryNestedParameter<TEntity> Expand(Action<IODataQueryNestedBuilder<TEntity>> entityExpandNested);

        IODataQueryNestedParameter<TEntity> Expand(Expression<Func<TEntity, object>> entityNestedExpand);

        IODataQueryNestedParameter<TEntity> Select(Expression<Func<TEntity, object>> entityNestedSelect);
    }
}