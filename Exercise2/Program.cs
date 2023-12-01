int[] numeros = new int[10];

for (int i = 0; i < numeros.Length; i++)
{
    Console.WriteLine("Informe o número na posição {0}: ", i + 1);
    numeros[i] = int.Parse(Console.ReadLine());
}

for (int i = numeros.Length - 1; i >= 0; i--)
{
    Console.WriteLine(numeros[i]);
}