using System.Collections.Generic;
using NHibernate.Hql.Ast;

namespace agilex.persistence.nhibernate
{
    internal static class UnionExtension
    {
        public static IEnumerable<HqlTreeNode> Union(this HqlTreeNode first, IEnumerable<HqlTreeNode> rest)
        {
            yield return first;

            foreach (HqlTreeNode x in rest)
            {
                yield return x;
            }
        }
    }
}