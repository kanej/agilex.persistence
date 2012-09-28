using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;
using NHibernate.Hql.Ast;
using NHibernate.Linq;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;

namespace agilex.persistence.nhibernate
{
    public class NhibExtensionsGenerator : BaseHqlGeneratorForMethod
    {
        public NhibExtensionsGenerator()
        {
            SupportedMethods = new[]
                                   {
                                       ReflectionHelper.GetMethodDefinition(() => NhibOperatorExtensions.ParseInt(null)),
                                   };
        }

        public override HqlTreeNode BuildHql(MethodInfo method, Expression targetObject,
                                             ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            return treeBuilder.Cast(visitor.Visit(arguments[0]).AsExpression(), typeof (int));
        }
    }
}