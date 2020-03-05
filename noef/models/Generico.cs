using System;
using System.Collections.Generic;
using System.Text;

namespace noef.models
{
    public class Generico
    {
        private string columna;

        private object valor;

        public string Columna { get => columna; set => columna = value; }
        public object Valor { get => valor; set => valor = value; }
    }
}
