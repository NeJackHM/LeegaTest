using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsFor4And5.Data
{
    public class IngressoVIP : Ingresso
    {
        public int ValorAdicional { get; set; }

        public override string ToString()
        {
            return $"Valor do ingresso: {Valor + ValorAdicional}";
        }
    }
}
