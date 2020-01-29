using noef.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noef.controllers
{
    public class selects
    {
        public async Task<List<object>> Get(Conexion con,string consulta)
        {


            List<object> resultados = new List<object>();

            try
            {
                bool hayConsulta = consulta != null ? true : false;

                if (hayConsulta)
                {
                    bool servidor = !string.IsNullOrWhiteSpace(con.Servidor) ? true : false;

                    bool bd = !string.IsNullOrWhiteSpace(con.BD) ? true : false;

                    bool usuario = !string.IsNullOrWhiteSpace(con.Usuario) ? true : false;

                    bool clave = !string.IsNullOrWhiteSpace(con.Password) ? true : false;

                   

                    if (servidor && bd && usuario && clave )
                    {

                        


                        using (sqlhandle sql = new sqlhandle(con.Servidor, con.BD, con.Usuario, con.Password))
                        {

                           await sql.conectar();

                            sql.Consulta = consulta;

                            using (sql.Comando = new SqlCommand(sql.Consulta, sql.Conexionn))
                            {
                                await sql.Comando.ExecuteNonQueryAsync();


                                using (SqlDataReader lector = await sql.Comando.ExecuteReaderAsync())
                                {
                                    while (await lector.ReadAsync())
                                    {
                                        

                                        foreach (var item in lector.Cast<DbDataRecord>())
                                        {
                                            for (int i = 0; i < item.FieldCount; i++)
                                            {
                                                if (item.GetValue(i)!=null)
                                                {

                                                    var anonimo = new { columna = item.GetName(i), valor = item.GetValue(i) };


                                                    resultados.Add(anonimo);
                                                }
                                            }
                                        }
                                    }


                                }
                            }
                        }



                        return resultados;

                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                return null;
            }


        }
    }
}
