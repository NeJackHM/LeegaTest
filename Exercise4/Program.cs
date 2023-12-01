public static class DataExtensions
{
    public static int ToAnoMes(this DateTime data)
    {
        return data.Year * 100 + data.Month;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string dataStr;

        Console.WriteLine("Insira uma data (dd/MM/yyyy): ");
        dataStr = Console.ReadLine();

        DateTime data = DateTime.Parse(dataStr);

        int anoMes = DataExtensions.ToAnoMes(data);

        Console.WriteLine($"Data: {anoMes}");
    }
}
