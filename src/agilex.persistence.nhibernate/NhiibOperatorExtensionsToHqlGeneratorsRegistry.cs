using NHibernate.Linq;
using NHibernate.Linq.Functions;

namespace agilex.persistence.nhibernate
{
    public class NhiibOperatorExtensionsToHqlGeneratorsRegistry : DefaultLinqToHqlGeneratorsRegistry
    {
        public NhiibOperatorExtensionsToHqlGeneratorsRegistry()
            : base()
        {
            RegisterGenerator(ReflectionHelper.GetMethodDefinition(() => NhibOperatorExtensions.CompareInt(null, null, 0)),
                              new NhibOperatorGenerator());
        }
    }
}