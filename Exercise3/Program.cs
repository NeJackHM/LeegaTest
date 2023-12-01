class Aluno
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public int Matricula { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Aluno> alunos = new List<Aluno>();

        alunos.Add(new Aluno { Nome = "Matheus", Idade = 20, Matricula = 103 });
        alunos.Add(new Aluno { Nome = "Lucas", Idade = 21, Matricula = 102 });
        alunos.Add(new Aluno { Nome = "Marcelo", Idade = 22, Matricula = 101 });

        var alunosOrdenados = alunos.OrderBy(a => a.Matricula);

        foreach (var aluno in alunosOrdenados)
        {
            Console.WriteLine($"Nome: {aluno.Nome}, Idade: {aluno.Idade}, Matricula: {aluno.Matricula}");
        }
    }
}
