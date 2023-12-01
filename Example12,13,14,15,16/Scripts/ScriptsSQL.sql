-- 12. Crie uma tabela de alunos com as propriedades: Matricula (inteiro), Nome (Texto) e Idade (inteiro), Estado (texto).

CREATE TABLE Alunos
(
  Matricula INT NOT NULL IDENTITY,
  Nome VARCHAR(255) NOT NULL,
  Idade INT NOT NULL,
  Estado VARCHAR(255) NOT NULL,
  PRIMARY KEY (Matricula)
);

--13. Insira, de uma só vez, os registros abaixo na tabela criada

INSERT INTO Alunos (Nome, Idade, Estado)
VALUES
('João', 21, 'SP'),
('Maria', 20, 'RJ'),
('José', 19, 'MG'),
('Ana', 18, 'DF'),
('Pedro', 22, 'RS');

--14. Crie uma procedure que permita alterar a idade de um aluno para 22 anos na tabela criada.

CREATE PROCEDURE AlterarIdadeAluno
@Matricula INT
AS
BEGIN
  UPDATE Alunos
  SET Idade = 22
  WHERE Matricula = @Matricula;
END;

--15. Crie uma tabela que guarde as informações de campus contendo as seguintes propriedades: Id (inteiro), Nome do campus (texto), Estado (texto)

CREATE TABLE Campus
(
  Id INT NOT NULL IDENTITY,
  Nome VARCHAR(255) NOT NULL,
  Estado VARCHAR(255) NOT NULL,
  PRIMARY KEY (Id)
);

--15.1 - Insira, de uma só vez, os registros abaixo na tabela criada

INSERT INTO Campus (Nome, Estado)
VALUES
('Campus A', 'SP'),
('Campus B', 'RJ'),
('Campus C', 'MG'),
('Campus D', 'DF'),
('Campus E', 'RS');

--15.2 – Crie uma consulta que cruze a tabela de alunos e a tabela de campus e identifique em quais campus cada aluno estuda.

SELECT
  a.Nome,
  c.Nome AS Campus
FROM Alunos a
INNER JOIN Campus c
ON a.IdCampus = c.Id;

--15.3 – Você acha possível melhorar a consulta do item 15.2? Se sim, como?

--Usando um JOIN INNER CROSS, que retornará todas as combinações de alunos e campus, mesmo que não haja um relacionamento entre eles.

--16 – Remova todos os alunos com menos de 20 anos e que o nome possua mais de 5 caracteres.

DELETE FROM Alunos
WHERE Idade < 20 AND Nome LIKE '%%';

