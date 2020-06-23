﻿using OData.QueryBuilder.Builders.Resourses;
using OData.QueryBuilder.Conventions.Constants;
using OData.QueryBuilder.Visitors;
using System;
using System.Linq.Expressions;

namespace OData.QueryBuilder.Builders
{
    public class ODataQueryBuilder<TResource> : IODataQueryBuilder<TResource>
    {
        private readonly string _baseUrl;

        public ODataQueryBuilder(Uri baseUrl)
        {
            _baseUrl = $"{baseUrl.OriginalString.TrimEnd(QuerySeparators.SlashChar)}{QuerySeparators.SlashString}";
        }

        public ODataQueryBuilder(string baseUrl)
        {
            _baseUrl = $"{baseUrl.TrimEnd(QuerySeparators.SlashChar)}{QuerySeparators.SlashString}";
        }

        public IODataQueryResource<TEntity> For<TEntity>(Expression<Func<TResource, object>> entityResource)
        {
            var visitor = new VisitorExpression(entityResource.Body);
            var query = visitor.ToString();

            return new ODataQueryResource<TEntity>($"{_baseUrl}{query}");
        }
    }
}