namespace Exercise7
{
    public class Vendedor
    {
        public string Nome { get; set; }
        public string Regiao { get; set; }
        public int Vendas { get; set; }

        public Vendedor(string nome, string regiao, int vendas)
        {
            Nome = nome;
            Regiao = regiao;
            Vendas = vendas;
        }
    }
}
