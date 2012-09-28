using NHibernate.Linq;
using NHibernate.Linq.Functions;

namespace agilex.persistence.nhibernate
{
    public class NhibDoubleExtensionsToHqlGeneratorsRegistry : DefaultLinqToHqlGeneratorsRegistry
    {
        public NhibDoubleExtensionsToHqlGeneratorsRegistry()
            : base()
        {
            RegisterGenerator(ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.GreaterThan(null, 0)),
                              new NhibDoubleGenerator());
            RegisterGenerator(ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.GreaterThanEqualTo(null, 0)),
                              new NhibDoubleGenerator());
            RegisterGenerator(ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.LessThan(null, 0)),
                              new NhibDoubleGenerator());
            RegisterGenerator(ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.LessThanEqualTo(null, 0)),
                              new NhibDoubleGenerator());
            RegisterGenerator(ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.EqualTo(null, 0)),
                              new NhibDoubleGenerator());
            RegisterGenerator(ReflectionHelper.GetMethodDefinition(() => NhibIntExtensions.NoEqualTo(null, 0)),
                              new NhibDoubleGenerator());
        }
    }
}