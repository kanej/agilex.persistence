using System.Collections.Generic;
using System.Reflection;

namespace agilex.persistence
{
    public interface IDatabaseConfigurationParams
    {
        string ConnectionString { get; }
        IEnumerable<Assembly> Assemblies { get; }
        string SchemaExportLocation { get; }
        bool BlowDbAway { get; }
        Dialect Dialect { get; }
        bool ShowSql { get; }
    }
}