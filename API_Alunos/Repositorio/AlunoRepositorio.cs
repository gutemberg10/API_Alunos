using API_Alunos.Context;
using API_Alunos.Models;
using API_Alunos.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Alunos.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly AppDbContext _dbContext;
        public AlunoRepositorio(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public async Task<AlunoModel> BuscarPorId(int id)
        {
            return await _dbContext.Alunos.FirstOrDefaultAsync(x => x.AlunoId == id);
        }

        public async Task<List<AlunoModel>> BuscarTodosAlunos()
        {
            return await _dbContext.Alunos.ToListAsync();
        }

        public async Task<AlunoModel> Adicionar(AlunoModel aluno)
        {
            await _dbContext.Alunos.AddAsync(aluno);
            await _dbContext.SaveChangesAsync();

            if (aluno(aluno => aluno.cpf == cpf))
            {
                aluno.Add(aluno);
                Console.WriteLine("ALUNO CADASTRADO COM SUCESSO.");
            }
            else
            {
                Console.WriteLine("CPF JÁ EXISTE NA BASE, CADASTRO RECUSADO.");
            }

            return aluno;
        }

        public async Task<AlunoModel> Atualizar(AlunoModel aluno, int id)
        {
            AlunoModel alunoPorId = await BuscarPorId(id);

            if (alunoPorId == null)
            {
                throw new Exception($"Aluno para o ID: {id} não foi encontrado no banco de dados.");
            }

            alunoPorId.email = aluno.email;
            alunoPorId.Nome = aluno.Nome;

            _dbContext.Alunos.Update(alunoPorId);
            await _dbContext.SaveChangesAsync();

            return alunoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            AlunoModel alunoPorId = await BuscarPorId(id);

            if (alunoPorId == null)
            {
                throw new Exception($"Aluno para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Alunos.Remove(alunoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }  
        

    }
}
