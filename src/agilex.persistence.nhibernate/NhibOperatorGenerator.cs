using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;
using NHibernate.Hql.Ast;
using NHibernate.Linq;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;

namespace agilex.persistence.nhibernate
{
    public class NhibOperatorGenerator : BaseHqlGeneratorForMethod
    {
        public NhibOperatorGenerator()
        {
            SupportedMethods = new[]
                                   {
                                       ReflectionHelper.GetMethodDefinition(() => NhibOperatorExtensions.CompareInt(null, null, 0)),
                                   };
        }

        public override HqlTreeNode BuildHql(MethodInfo method, Expression targetObject,
                                             ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            return treeBuilder.Like(visitor.Visit(arguments[0]).AsExpression(),
                                    visitor.Visit(arguments[1]).AsExpression());
        }
    }
}