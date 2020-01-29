using System;
using System.Collections.Generic;
using System.Text;

namespace noef.models
{
    public class Conexion
    {
        private string servidor;
        private string bD;
        private string usuario;
        private string password;

        public string Servidor { get => servidor; set => servidor = value; }

        public string BD { get => bD; set => bD = value; }

        public string Usuario { get => usuario; set => usuario = value; }

        public string Password { get => password; set => password = value; }
    }
}
