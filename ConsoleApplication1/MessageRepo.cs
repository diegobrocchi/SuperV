using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  public class MessageRepo
    {
     
        readonly string _connString =
        ConfigurationManager.ConnectionStrings["SupervisoreDB"].ConnectionString;

        public IEnumerable<string> GetAllMessages()
        {
            var messages = new List<string>();
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

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        messages.Add(item: 
                         
                             ((int)reader["AverageSpeed"]).ToString()
                            );
                    }
                }
            }
            return messages;
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                Console.WriteLine("H");
            }
        }
    }
}