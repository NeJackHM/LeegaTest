namespace MyNamespace
{
    public class UnitTestFor4
    {
        [Fact]
        public void ToAnoMesShouldReturnCorrectValue()
        {
            var data = new DateTime(2023, 11, 6);

            var anoMes = DataExtensions.ToAnoMes(data);

            Assert.Equal(202311, anoMes);
        }
    }
}