using TestsFor4And5.Data;

namespace TestsFor4And5
{
    public class IngressoTests
    {
        [Fact]
        public void IngressoDeveRetornarValorDoIngresso()
        {
            Ingresso ingresso = new Ingresso();
            ingresso.Valor = 100;

            string valor = ingresso.ToString();

            Assert.Equal("Valor do ingresso: 100", valor);
        }

        [Fact]
        public void IngressoVIPDeveRetornarValorDoIngressoComAdicional()
        {
            IngressoVIP ingressoVIP = new IngressoVIP();
            ingressoVIP.Valor = 100;
            ingressoVIP.ValorAdicional = 50;

            string valor = ingressoVIP.ToString();

            Assert.Equal("Valor do ingresso: 150", valor);
        }
    }
}
