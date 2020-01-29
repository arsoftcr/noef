using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace noef.controllers
{
    public class sqlhandle : IDisposable
    {
        public SqlConnection Conexionn;

        public SqlCommand Comando;

        public string Consulta;

        public sqlhandle(string server, string bd, string usuario, string pass)
        {
            Conexionn = new SqlConnection(
                "Server=" + server + ";Initial Catalog=" + bd + ";User Id=" + usuario + ";Password=" + pass + ";");
        }

        public async Task<bool> conectar()
        {
            bool proceso = false;

            try
            {


               await Conexionn.OpenAsync();

                proceso = true;
            }
            catch (Exception r)
            {

                proceso = false;
            }





            return proceso;

        }

        public void Dispose()
        {
            Conexionn = null;

            Comando = null;

            Consulta = null;
        }
    }
}
