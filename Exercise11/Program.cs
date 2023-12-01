using System;
using System.Linq;

namespace MyNamespace
{
    public class Vendedor
    {
        public int Orcado { get; set; }
        public int Realizado { get; set; }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            var vendedores = new List<Vendedor>()
            {
                new Vendedor { Orcado = 1000, Realizado = 800 },
                new Vendedor { Orcado = 2000, Realizado = 1500 },
                new Vendedor { Orcado = 3000, Realizado = 2500 }
            };

            var vendedoresComOrcado = vendedores.Where(vendedor => vendedor.Orcado > 0);

            var percentualAtingimento = vendedoresComOrcado.Average(vendedor => ((double)vendedor.Realizado / vendedor.Orcado) * 100);

            Console.WriteLine(percentualAtingimento);
        }
    }
}
