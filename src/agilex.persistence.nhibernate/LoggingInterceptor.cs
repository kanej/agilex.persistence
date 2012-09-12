using System.Diagnostics;
using NHibernate;
using NHibernate.SqlCommand;

namespace agilex.persistence.nhibernate
{
    public class LoggingInterceptor : EmptyInterceptor
    {
        public override SqlString OnPrepareStatement(SqlString sql)
        {
            Debug.WriteLine(sql);
            return base.OnPrepareStatement(sql);
        }
    }
}