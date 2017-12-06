using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SuperV
{
    /// <summary>
    /// Questo oggetto registra le dipendenze SQL.
    /// </summary>
    public class SQLDependencyManager
    {
        readonly string _connString = ConfigurationManager.ConnectionStrings["SupervisoreDB"].ConnectionString;

        public void RegisterSQLDependencyOnTableMachineStatus()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"SELECT [MachineID]
                                                            ,[ProductCode]
                                                            ,[MachineStateID]
                                                            ,[Speed]
                                                            ,[AverageSpeed]
                                                            ,[Counter]
                                                            ,[ResettableCounter]
                                                            ,[ErrorString]
                                                    FROM [dbo].[MachineStatus]", connection))
                {
                    command.Notification = null;

                    var dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        //non fa niente a parte eseguire il comando
                        //server per registrare la SqlDependency
                    }
                }
            }
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                var hub = new SR_firstHub();

                hub.GetLastData();

                RegisterSQLDependencyOnTableMachineStatus();
            }
        }
    }
}