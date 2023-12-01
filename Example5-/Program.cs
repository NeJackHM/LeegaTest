using System.ServiceModel;

namespace Exercise5
{
    [ServiceContract]
    public interface IFibonacciService
    {
        [OperationContract]
        double CalcularProximoFibonacci(int posicao);
    }

    public class FibonacciServiceImplementation : IFibonacciService
    {
        public double CalcularProximoFibonacci(int posicao)
        {
            if (posicao < 0)
            {
                throw new ArgumentOutOfRangeException("A posição deve ser um número positivo.");
            }

            var fibonacciSeq = new List<int>();
            fibonacciSeq.Add(0);
            fibonacciSeq.Add(1);

            for (int i = 2; i <= posicao; i++)
            {
                fibonacciSeq.Add(fibonacciSeq[i - 1] + fibonacciSeq[i - 2]);
            }

            return fibonacciSeq[posicao];
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            //var serviceHost = new ServiceHost(typeof(FibonacciServiceImplementation));

            //serviceHost.Open();

            Console.WriteLine("Pressione ENTER para parar o serviço...");
            Console.ReadLine();

            //serviceHost.Close();
        }
    }
}