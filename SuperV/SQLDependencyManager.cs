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
        private static SQLDependencyManager _instance = null;

        protected  SQLDependencyManager()
        {
        }

        public static SQLDependencyManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SQLDependencyManager();

                return _instance;
            }
        }

        readonly string _connString = ConfigurationManager.ConnectionStrings["SupervisoreDBIdentity"].ConnectionString;
        private bool _isRegistered;

        public bool IsRegistered
        {
            get
            {
                return _isRegistered;
            }
        }

        public void RegisterSQLDependencyOnTableMachineStatus()
        {
            if (!IsRegistered)
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
                                                            ,[ErrorsString]
                                                            ,[StartPhase]
                                                            ,[LastUpdate]
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
                            //serve per registrare la SqlDependency
                            if (!_isRegistered)
                                _isRegistered = true;
                        }
                    }
                }
            }
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                _isRegistered = false;

                var hub = new SignalRHub();
                hub.GetLastData();
                RegisterSQLDependencyOnTableMachineStatus();
            }
        }
    }
}