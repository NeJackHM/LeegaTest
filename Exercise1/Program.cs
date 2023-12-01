int i;
double salary, adjust, newSalary;

for (i = 0; i < 10; i++)
{
    Console.WriteLine("Informe o salário do funcionário: ");
    salary = Convert.ToDouble(Console.ReadLine());

    if (salary <= 300)
    {
        adjust = 1.5;
    }
    else
    {
        adjust = 1.3;
    }
    newSalary = salary * adjust;

    Console.WriteLine("Salário reajustado: " + newSalary);
}
Console.ReadLine();
