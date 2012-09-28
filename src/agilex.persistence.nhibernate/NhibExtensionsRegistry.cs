using NHibernate.Linq;
using NHibernate.Linq.Functions;

namespace agilex.persistence.nhibernate
{
    public class NhibExtensionsRegistry : DefaultLinqToHqlGeneratorsRegistry
    {
        public NhibExtensionsRegistry()
        {
            RegisterGenerator(ReflectionHelper.GetMethodDefinition(() => NhibOperatorExtensions.ParseInt(null)),
                              new NhibExtensionsGenerator());
        }
    }
}