using System;
using System.Collections.Generic;
using System.Text;

namespace noef.models
{
  

    public class ConexionSQL {

        private string servidor;
        private string bD;
        private string usuario;
        private string password;

        public string Servidor { get => servidor; set => servidor = value; }

        public string BD { get => bD; set => bD = value; }

        public string Usuario { get => usuario; set => usuario = value; }

        public string Password { get => password; set => password = value; }

    }

    public class ConexionPostgres
    {

        private string host;
        private string port;
        private string userId;
        private string password;
        private string database;

        public string Host { get => host; set => host = value; }
        public string Port { get => port; set => port = value; }
        public string UserId { get => userId; set => userId = value; }
        public string Password { get => password; set => password = value; }
        public string Database { get => database; set => database = value; }
    }

    public class ConexionOracle
    {

        private string datasource;
        private string port;
        private string userId;
        private string password;
        private string servicio;

        public string Datasource { get => datasource; set => datasource = value; }
        public string Port { get => port; set => port = value; }
        public string UserId { get => userId; set => userId = value; }
        public string Password { get => password; set => password = value; }
        public string Servicio { get => servicio; set => servicio = value; }
    }

    public class ConexionMysql
    {

        private string server;
        private string port;
        private string username;
        private string password;
        private string bd;

        public string Server { get => server; set => server = value; }
        public string Port { get => port; set => port = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Bd { get => bd; set => bd = value; }
    }

}
