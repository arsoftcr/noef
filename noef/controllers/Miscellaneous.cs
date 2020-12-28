using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using noef.models;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noef.controllers
{
    public class Miscellaneous
    {
        public static string createConnection(Connection con)
        {
            string pConnection = string.Empty;

            switch ((con ?? new Connection()).TypeConnection)
            {
                case typeConnection.SQL:
                    pConnection = $"Server={con.Server};Initial Catalog={con.Bd};User Id={con.User};Password={con.Password};Persist Security Info=True;MultipleActiveResultSets=True;";
                    break;
                case typeConnection.Oracle:
                    pConnection = $"Data Source={con.Server}:{con.Port}/{con.Bd};User Id={con.User};Password={con.Password};";
                    break;
                case typeConnection.Postgres:
                    pConnection = $"Host={con.Server};Port={con.Port};User ID={con.User};Password={con.Password};Database={con.Bd}";
                    break;
                case typeConnection.Mysql:
                    pConnection = $"server={con.Server};port={con.Port};username={con.User};password={con.Password};SslMode = none;database={con.Bd}";
                    break;
                default:
                    break;
            }

            return pConnection;
        }


        public static async Task<string> addResults(object reader)
        {
            
            string payload = "";

            List<ExpandoObject> expandos = new List<ExpandoObject>();

            IDictionary<string, object> props = new ExpandoObject();

            string typeOfReader = reader != null ? reader.GetType().Name : "";

            switch (typeOfReader)
            {
                case "SqlDataReader":
                    foreach (var item in (reader as System.Data.SqlClient.SqlDataReader).Cast<System.Data.Common.DbDataRecord>())
                    {
                        props = new ExpandoObject();
                        for (int i = 0; i < item.FieldCount; i++)
                        {
                            if (item.GetValue(i) != null)
                            {
                                props[$"{item.GetName(i) ?? ""}"] = item.GetValue(i);

                            }
                        }


                        expandos.Add((ExpandoObject)props);

                    }

                    //Múltiple result sets
                    while (await (reader as System.Data.SqlClient.SqlDataReader).NextResultAsync())
                    {
                        props = new ExpandoObject();
                        foreach (var item in (reader as System.Data.SqlClient.SqlDataReader).Cast<System.Data.Common.DbDataRecord>())
                        {

                            for (int i = 0; i < item.FieldCount; i++)
                            {
                                if (item.GetValue(i) != null)
                                {
                                    props[(item.GetName(i) ?? "").ToString()] = item.GetValue(i);

                                }
                            }


                            expandos.Add((ExpandoObject)props);

                        }
                    }

                    payload = JsonConvert.SerializeObject(expandos, Formatting.Indented);
                    break;
                case "MySqlDataReader":
                    foreach (var item in (reader as MySqlDataReader).Cast<System.Data.Common.DbDataRecord>())
                    {
                        props = new ExpandoObject();
                        for (int i = 0; i < item.FieldCount; i++)
                        {
                            if (item.GetValue(i) != null)
                            {
                                props[(item.GetName(i) ?? "").ToString()] = item.GetValue(i);

                            }
                        }


                        expandos.Add((ExpandoObject)props);

                    }

                    //Múltiple result sets
                    while (await (reader as MySqlDataReader).NextResultAsync())
                    {
                        foreach (var item in (reader as MySqlDataReader).Cast<System.Data.Common.DbDataRecord>())
                        {
                            props = new ExpandoObject();
                            for (int i = 0; i < item.FieldCount; i++)
                            {
                                if (item.GetValue(i) != null)
                                {
                                    props[(item.GetName(i) ?? "").ToString()] = item.GetValue(i);

                                }
                            }


                            expandos.Add((ExpandoObject)props);

                        }
                    }

                    payload = JsonConvert.SerializeObject(expandos, Formatting.Indented);
                    break;
                case "NpgsqlDataReader":
                    foreach (var item in (reader as NpgsqlDataReader).Cast<System.Data.Common.DbDataRecord>())
                    {
                        props = new ExpandoObject();
                        for (int i = 0; i < item.FieldCount; i++)
                        {
                            if (item.GetValue(i) != null)
                            {
                                props[(item.GetName(i) ?? "").ToString()] = item.GetValue(i);

                            }
                        }


                        expandos.Add((ExpandoObject)props);

                    }

                    //Múltiple result sets
                    while (await (reader as NpgsqlDataReader).NextResultAsync())
                    {
                        foreach (var item in (reader as NpgsqlDataReader).Cast<System.Data.Common.DbDataRecord>())
                        {
                            props = new ExpandoObject();
                            for (int i = 0; i < item.FieldCount; i++)
                            {
                                if (item.GetValue(i) != null)
                                {
                                    props[(item.GetName(i) ?? "").ToString()] = item.GetValue(i);

                                }
                            }


                            expandos.Add((ExpandoObject)props);

                        }
                    }

                    payload = JsonConvert.SerializeObject(expandos, Formatting.Indented);
                    break;
                case "OracleDataReader":
                    foreach (var item in (reader as System.Data.SqlClient.SqlDataReader).Cast<System.Data.Common.DbDataRecord>())
                    {
                        props = new ExpandoObject();
                        for (int i = 0; i < item.FieldCount; i++)
                        {
                            if (item.GetValue(i) != null)
                            {
                                props[(item.GetName(i) ?? "").ToString()] = item.GetValue(i);

                            }
                        }


                        expandos.Add((ExpandoObject)props);

                    }

                    //Múltiple result sets
                    while (await (reader as Oracle.ManagedDataAccess.Client.OracleDataReader).NextResultAsync())
                    {
                        foreach (var item in (reader as System.Data.SqlClient.SqlDataReader).Cast<System.Data.Common.DbDataRecord>())
                        {
                            props = new ExpandoObject();
                            for (int i = 0; i < item.FieldCount; i++)
                            {
                                if (item.GetValue(i) != null)
                                {
                                    props[(item.GetName(i) ?? "").ToString()] = item.GetValue(i);

                                }
                            }


                            expandos.Add((ExpandoObject)props);

                        }
                    }

                    payload = JsonConvert.SerializeObject(expandos, Formatting.Indented);
                    break;
                default:
                    break;
            }

            return payload;

        }

        public static async Task<List<ExpandoObject>> addResultsGenericObject(object reader)
        {
            List<ExpandoObject> expandos = new List<ExpandoObject>();

            IDictionary<string, object> props = new ExpandoObject();

            string typeOfReader = reader != null ? reader.GetType().Name : "";

            switch (typeOfReader)
            {
                case "SqlDataReader":
                    foreach (var item in (reader as System.Data.SqlClient.SqlDataReader).Cast<System.Data.Common.DbDataRecord>())
                    {
                        props = new ExpandoObject();
                        for (int i = 0; i < item.FieldCount; i++)
                        {
                            if (item.GetValue(i) != null)
                            {
                                props[$"{item.GetName(i) ?? ""}"] = item.GetValue(i);

                            }
                        }


                        expandos.Add((ExpandoObject)props);

                    }

                    //Múltiple result sets
                    while (await (reader as System.Data.SqlClient.SqlDataReader).NextResultAsync())
                    {
                        props = new ExpandoObject();
                        foreach (var item in (reader as System.Data.SqlClient.SqlDataReader).Cast<System.Data.Common.DbDataRecord>())
                        {

                            for (int i = 0; i < item.FieldCount; i++)
                            {
                                if (item.GetValue(i) != null)
                                {
                                    props[(item.GetName(i) ?? "").ToString()] = item.GetValue(i);

                                }
                            }


                            expandos.Add((ExpandoObject)props);

                        }
                    }

                    break;
                case "MySqlDataReader":
                    foreach (var item in (reader as MySqlDataReader).Cast<System.Data.Common.DbDataRecord>())
                    {
                        props = new ExpandoObject();
                        for (int i = 0; i < item.FieldCount; i++)
                        {
                            if (item.GetValue(i) != null)
                            {
                                props[(item.GetName(i) ?? "").ToString()] = item.GetValue(i);

                            }
                        }


                        expandos.Add((ExpandoObject)props);

                    }

                    //Múltiple result sets
                    while (await (reader as MySqlDataReader).NextResultAsync())
                    {
                        foreach (var item in (reader as MySqlDataReader).Cast<System.Data.Common.DbDataRecord>())
                        {
                            props = new ExpandoObject();
                            for (int i = 0; i < item.FieldCount; i++)
                            {
                                if (item.GetValue(i) != null)
                                {
                                    props[(item.GetName(i) ?? "").ToString()] = item.GetValue(i);

                                }
                            }


                            expandos.Add((ExpandoObject)props);

                        }
                    }

                    break;
                case "NpgsqlDataReader":
                    foreach (var item in (reader as NpgsqlDataReader).Cast<System.Data.Common.DbDataRecord>())
                    {
                        props = new ExpandoObject();
                        for (int i = 0; i < item.FieldCount; i++)
                        {
                            if (item.GetValue(i) != null)
                            {
                                props[(item.GetName(i) ?? "").ToString()] = item.GetValue(i);

                            }
                        }


                        expandos.Add((ExpandoObject)props);

                    }

                    //Múltiple result sets
                    while (await (reader as NpgsqlDataReader).NextResultAsync())
                    {
                        foreach (var item in (reader as NpgsqlDataReader).Cast<System.Data.Common.DbDataRecord>())
                        {
                            props = new ExpandoObject();
                            for (int i = 0; i < item.FieldCount; i++)
                            {
                                if (item.GetValue(i) != null)
                                {
                                    props[(item.GetName(i) ?? "").ToString()] = item.GetValue(i);

                                }
                            }


                            expandos.Add((ExpandoObject)props);

                        }
                    }

                    break;
                case "OracleDataReader":
                    foreach (var item in (reader as System.Data.SqlClient.SqlDataReader).Cast<System.Data.Common.DbDataRecord>())
                    {
                        props = new ExpandoObject();
                        for (int i = 0; i < item.FieldCount; i++)
                        {
                            if (item.GetValue(i) != null)
                            {
                                props[(item.GetName(i) ?? "").ToString()] = item.GetValue(i);

                            }
                        }


                        expandos.Add((ExpandoObject)props);

                    }

                    //Múltiple result sets
                    while (await (reader as Oracle.ManagedDataAccess.Client.OracleDataReader).NextResultAsync())
                    {
                        foreach (var item in (reader as System.Data.SqlClient.SqlDataReader).Cast<System.Data.Common.DbDataRecord>())
                        {
                            props = new ExpandoObject();
                            for (int i = 0; i < item.FieldCount; i++)
                            {
                                if (item.GetValue(i) != null)
                                {
                                    props[(item.GetName(i) ?? "").ToString()] = item.GetValue(i);

                                }
                            }


                            expandos.Add((ExpandoObject)props);

                        }
                    }
                    break;
                default:
                    break;
            }

            return expandos;

        }


        public static object addParameters(object command, Dictionary<string, object> param)
        {
            string typeCommand = command != null ? command.GetType().Name : "";
            try
            {
                switch (typeCommand)
                {
                    case "SqlCommand":

                        foreach (var item in param)
                        {
                            (command as SqlCommand).Parameters.AddWithValue(item.Key, item.Value);
                        }


                        break;


                    case "OracleCommand":

                        foreach (var item in param)
                        {
                            (command as OracleCommand).Parameters.Add(new OracleParameter(item.Key, item.Value));
                        }

                        break;
                    case "MySqlCommand":

                        foreach (var item in param)
                        {
                            (command as MySqlCommand).Parameters.AddWithValue(item.Key, item.Value);
                        }

                        break;
                    case "NpgsqlCommand":

                        foreach (var item in param)
                        {

                            (command as NpgsqlCommand).Parameters.AddWithValue(item.Key.Replace("@", ""), item.Value);
                        }

                        break;
                    default:
                        break;
                }


            }
            catch (Exception g)
            {
                Console.WriteLine(g.ToString());
            }

            return command;

        }
    }
}
