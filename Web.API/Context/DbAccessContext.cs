
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using Web.API.Business.Concrete;
using Web.API.Helpers;

namespace Web.API.Context
{
    public class DbAccessContext
    {
        public static DataTable ExecuteReader(string commandText, ParameterInfo[] parameterNames, object[] parameterValues)
        {
            try
            {
                return MsSqlHelper.ExecuteDataTable(ConnectionString, CommandType.StoredProcedure, commandText, GenerateParam(parameterNames, parameterValues));
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public static bool ExecuteNonQuery(string commandText, ParameterInfo[] parameterNames, object[] parameterValues)
        {
            try
            {
                MsSqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, commandText, GenerateParam(parameterNames, parameterValues));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static SqlParameter[] GenerateParam(ParameterInfo[] parameterNames, params object[] parameterValues)
        {
            int length = parameterNames.Length;
            SqlParameter[] sqlParams = new SqlParameter[length];

            for (int i = 0; i < length; i++)
            {
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@" + parameterNames[i].Name;
                parameter.Value = parameterValues[i] == null ? "" : parameterValues[i];
                sqlParams[i] = parameter;
            }

            return sqlParams;
        }

        public static string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder msBuilder = new SqlConnectionStringBuilder()
                {
                    DataSource = ReadFile.ReadFileValue().DataSource,
                    InitialCatalog = ReadFile.ReadFileValue().InitialCatalog,
                    UserID = ReadFile.ReadFileValue().UserID,
                    Password = ReadFile.ReadFileValue().Password,
                    ConnectTimeout = 120
                };

                string connectionString = msBuilder.ToString();

                return connectionString;
            }
        }
    }
}
