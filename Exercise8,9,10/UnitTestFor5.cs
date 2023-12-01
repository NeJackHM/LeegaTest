using Example5;

namespace MyNamespace
{
    public class UnitTestFor5
    {
        private FibonacciServiceImplementation _fibonacciService;

        public UnitTestFor5()
        {
            _fibonacciService = new FibonacciServiceImplementation();
        }

        [Fact]
        public void CalcularProximoFibonacciShouldReturnCorrectValueForPositivePosition()
        {
            int posicao = 5;

            double proximoFibonacci = _fibonacciService.CalcularProximoFibonacci(posicao);

            Assert.Equal(5, proximoFibonacci);
        }

        [Fact]
        public void CalcularProximoFibonacciShouldThrowExceptionIfPositionIsNegative()
        {
            int posicao = -10;

            Assert.Throws<ArgumentOutOfRangeException>(() => _fibonacciService.CalcularProximoFibonacci(posicao));
        }
    }
}