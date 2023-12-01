using System.Collections.Generic;
using Example6;
using Microsoft.AspNetCore.Mvc;

public class PessoaController : ControllerBase
{
    private readonly List<Alunos> _alunos = new List<Alunos>();

    public PessoaController()
    {
        _alunos.Add(new Alunos { Id = 1, Nome = "João da Silva", Idade = 25, Matricula = "123456" });
        _alunos.Add(new Alunos { Id = 2, Nome = "Maria de Souza", Idade = 30, Matricula = "654321" });
    }

    [HttpGet]
    public IEnumerable<Alunos> GetAll()
    {
        return _alunos;
    }

    [HttpGet("{id}")]
    public Alunos GetById(int id)
    {
        return _alunos.Find(p => p.Id == id);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Alunos pessoa)
    {
        if (pessoa == null)
        {
            return BadRequest();
        }

        _alunos.Add(pessoa);

        return CreatedAtAction("GetById", new { id = pessoa.Id }, pessoa);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Alunos pessoa)
    {
        if (pessoa == null || id != pessoa.Id)
        {
            return BadRequest();
        }

        var pessoaToUpdate = _alunos.Find(p => p.Id == id);

        pessoaToUpdate.Nome = pessoa.Nome;
        pessoaToUpdate.Idade = pessoa.Idade;
        pessoaToUpdate.Matricula = pessoa.Matricula;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pessoaToDelete = _alunos.Find(p => p.Id == id);

        if (pessoaToDelete == null)
        {
            return NotFound();
        }

        _alunos.Remove(pessoaToDelete);

        return NoContent();
    }
}