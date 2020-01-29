using noef.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public async Task<List<object>> SelectFromDatabase(Conexion con,string consulta)
        {


            List<object> resultados = new List<object>();

            try
            {
                        using (var conexion=new SqlConnection("Server=" + con.Servidor + ";Initial Catalog=" + con.BD + ";User Id=" + con.Usuario + ";Password=" + con.Password + ";Persist Security Info=True;MultipleActiveResultSets=True;"))
                        {

                            await conexion.OpenAsync();

                            using (var comando=new SqlCommand(consulta,conexion))
                            {
                                var reader = await comando.ExecuteReaderAsync();

                                
                                    foreach (var item in reader.Cast<DbDataRecord>())
                                    {
                                        for (int i = 0; i < item.FieldCount; i++)
                                        {
                                            if (item.GetValue(i) != null)
                                            {

                                                var anonimo = new { columna = item.GetName(i), valor = item.GetValue(i) };


                                                resultados.Add(anonimo);
                                            }
                                        }
                                    }
                              
                            }
                        }  


                        return resultados;

            }
            catch (Exception e)
            {

                var anonimo = new { columna = "error", valor = e.ToString() };

                resultados.Add(anonimo);

                return resultados;
            }


        }
    }
}
