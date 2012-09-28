using NHibernate.Linq;
using NHibernate.Linq.Functions;

namespace agilex.persistence.nhibernate
{
    public class NhibExtensionsRegistry : DefaultLinqToHqlGeneratorsRegistry
    {
        public NhibExtensionsRegistry()
            : base()
        {
            RegisterGenerator(ReflectionHelper.GetMethodDefinition(() => NhibOperatorExtensions.CompareInt(null, null, 0)),
                              new NhibExtensionsGenerator());
            RegisterGenerator(ReflectionHelper.GetMethodDefinition(() => NhibOperatorExtensions.CompareInt(null, null, 0)),
                              new NhibExtensions2Generator());

            RegisterGenerator(ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.GreaterThan(null, 0)),
                              new NhibExtensionsGenerator());
            RegisterGenerator(ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.GreaterThanEqualTo(null, 0)),
                              new NhibExtensionsGenerator());
            RegisterGenerator(ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.LessThan(null, 0)),
                              new NhibExtensionsGenerator());
            RegisterGenerator(ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.LessThanEqualTo(null, 0)),
                              new NhibExtensionsGenerator());
            RegisterGenerator(ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.EqualTo(null, 0)),
                              new NhibExtensionsGenerator());
            RegisterGenerator(ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.NotEqualTo(null, 0)),
                              new NhibExtensionsGenerator());
        }
    }
}