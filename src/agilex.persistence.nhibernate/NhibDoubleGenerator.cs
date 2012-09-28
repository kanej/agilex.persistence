using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;
using NHibernate.Hql.Ast;
using NHibernate.Linq;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;

namespace agilex.persistence.nhibernate
{
    public class NhibDoubleGenerator : BaseHqlGeneratorForMethod
    {
        public NhibDoubleGenerator()
        {
            SupportedMethods = new[]
                                   {
                                       ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.GreaterThan(null, 0)),
                                       ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.GreaterThanEqualTo(null, 0)),
                                       ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.LessThan(null, 0)),
                                       ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.LessThanEqualTo(null, 0)),
                                       ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.EqualTo(null, 0)),
                                       ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.NoEqualTo(null, 0)),
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