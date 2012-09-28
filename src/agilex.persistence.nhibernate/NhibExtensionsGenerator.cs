using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;
using NHibernate.Hql.Ast;
using NHibernate.Linq;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;

namespace agilex.persistence.nhibernate
{
    public class NhibExtensions2Generator : NhibExtensionsGenerator
    {
        
    }
    public class NhibExtensionsGenerator : BaseHqlGeneratorForMethod
    {
        public NhibExtensionsGenerator()
        {
            SupportedMethods = new[]
                                   {
                                       ReflectionHelper.GetMethodDefinition(() => NhibOperatorExtensions.CompareInt(null, null, 0)),

                                       ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.GreaterThan(null, 0)),
                                       ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.GreaterThanEqualTo(null, 0)),
                                       ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.LessThan(null, 0)),
                                       ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.LessThanEqualTo(null, 0)),
                                       ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.EqualTo(null, 0)),
                                       ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.NotEqualTo(null, 0)),
                                   };
        }

        public override HqlTreeNode BuildHql(MethodInfo method, Expression targetObject,
                                             ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var @operator = Strip(arguments[1].ToString());
            var one = treeBuilder.Cast(visitor.Visit(arguments[0]).AsExpression(), typeof (int));
            var two = treeBuilder.Cast(visitor.Visit(arguments[2]).AsExpression(), typeof (int));
            switch (@operator)
            {
                case ">":return treeBuilder.GreaterThan(one, two);
                case ">=": return treeBuilder.GreaterThanOrEqual(one, two);
                case "<": return treeBuilder.LessThan(one, two);
                case "<=": return treeBuilder.LessThanOrEqual(one, two);
                case "=": return treeBuilder.Equality(one, two);
                case "==": return treeBuilder.Equality(one, two);
                //case "!=": return treeBuilder.(one, two);
                //case "<>": return treeBuilder.GreaterThan(one, two);
                default: throw new Exception(string.Format("Do not understand operator {0} when calling NhibOperatorExtensions.CompareInt", @operator));
            }
        }

        private string Strip(string s)
        {
            return s == null ? "" : s.Replace("\"", "");
        }
    }
}