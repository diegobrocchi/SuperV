using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SuperV
{
    public class SQLDependencyConfig
    {
        private static string connString = ConfigurationManager.ConnectionStrings["SupervisoreDBIdentity"].ConnectionString;

        
        public static void Start()
        {
            SqlDependency.Start(connString);

            var mg = SQLDependencyManager.Instance;

            //qui l'elenco di tutte le dipendenze SQL da sottoscrivere:
            mg.RegisterSQLDependencyOnTableMachineStatus();
        }

        public static void Stop()
        {
            SqlDependency.Stop(connString);

        }
    }
}