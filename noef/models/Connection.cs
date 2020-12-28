using System;
using System.Collections.Generic;
using System.Text;

namespace noef.models
{
    public class Connection
    {
        private string server;
        private string bd;
        private string user;
        private string password;
        private string port;
        private typeConnection typeConnection;

        public string Server { get => server; set => server = value; }
        public string Bd { get => bd; set => bd = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public string Port { get => port; set => port = value; }
        public typeConnection TypeConnection { get => typeConnection; set => typeConnection = value; }
    }

    public enum typeConnection
    {

        SQL = 1,
        Oracle = 2,
        Postgres = 3,
        Mysql = 4
    }
}
