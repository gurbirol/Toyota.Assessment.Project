using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Web.API.Helpers
{
    public class MsSqlHelper
    {
        public static DataTable ExecuteDataTable(string connectionString, CommandType myCommandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return MsSqlHelper.ExecuteDataTable(connection, myCommandType, commandText, commandParameters);
            }
        }

        public static DataTable ExecuteDataTable(SqlConnection connection, CommandType myCommandType, string commandText, params SqlParameter[] commandParameters)
        {
            DataSet dataSet = new DataSet();
            using (SqlCommand selectCommand = new SqlCommand())
            {
                selectCommand.Connection = connection;
                selectCommand.CommandText = commandText;
                selectCommand.CommandType = myCommandType;
                if (commandParameters != null)
                {
                    foreach (SqlParameter commandParameter in commandParameters)
                        selectCommand.Parameters.Add(commandParameter);
                }
                new SqlDataAdapter(selectCommand).Fill(dataSet);
                selectCommand.Parameters.Clear();
            }
            return dataSet.Tables[0];
        }

        public static int ExecuteNonQuery(string connectionString, CommandType myCommandType, string commandText, params SqlParameter[] parms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return MsSqlHelper.ExecuteNonQuery(connection, myCommandType, commandText, parms);
            }
        }

        public static int ExecuteNonQuery(SqlConnection connection, CommandType myCommandType, string commandText, params SqlParameter[] commandParameters)
        {
            int num = 0;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = commandText;
                sqlCommand.CommandType = myCommandType;
                if (commandParameters != null)
                {
                    foreach (SqlParameter commandParameter in commandParameters)
                        sqlCommand.Parameters.Add(commandParameter);
                }
                num = sqlCommand.ExecuteNonQuery();
                sqlCommand.Parameters.Clear();
            }
            return num;
        }
    }
}
