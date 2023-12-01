using Exercise7;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExtratoDeVendas
{
    public class Program
    {
        static void Main(string[] args)
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

            path = path.Replace($"bin\\Debug","");

            var arquivos = Directory.GetFiles(path);

            var arquivo = File.OpenRead(Path.Combine(path, "extrato de vendas.csv"));

            var leitor = new StreamReader(arquivo);

            var vendedores = new Dictionary<string, List<Vendedor>>();

            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();

                var dados = linha.Split(';');

                int numvalue;
                bool isNumber = int.TryParse(dados[2], out numvalue);
                if (isNumber)
                {
                    var vendedor = new Vendedor(dados[0], dados[1], int.Parse(dados[2]));

                    if (!vendedores.ContainsKey(dados[1]))
                    {
                        vendedores.Add(dados[1], new List<Vendedor>());
                    }

                    vendedores[dados[1]].Add(vendedor);
                }              
            }

            foreach (var regiao in vendedores.Keys)
            {
                var vendedor = vendedores[regiao].OrderByDescending(v => v.Vendas).FirstOrDefault();

                Console.WriteLine($"Região: {regiao}, Vendedor: {vendedor.Nome}, Vendas: {vendedor.Vendas}");
            }

            leitor.Close();
        }     
    }
}