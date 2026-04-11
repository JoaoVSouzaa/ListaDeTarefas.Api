using ListaDeTarefas.Api.Data;
using ListaDeTarefas.Api.Models;
using ListaDeTarefas.Api.Enums;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Api.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tarefa>> ObterTodasTarefasAsync()
        {
            return await _context.Tarefas
                .OrderBy(t => t.DataCriacao)
                .ToListAsync();
        }

        public async Task<List<Tarefa>> ObterPorStatusAsync(StatusTarefa status)
        {
            return await _context.Tarefas
                .Where(t => t.Status == status)
                .OrderBy(t => t.DataCriacao)
                .ToListAsync();
        }

        public async Task<Tarefa> ObterPorIdAsync(Guid id)
        {
            return await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AdicionarTarefaAsync(Tarefa tarefa)
        {
            await _context.Tarefas.AddAsync(tarefa);
        }
        public void AtualizarTarefaAsync(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
        }
        public void RemoverTarefaAsync(Tarefa tarefa)
        {
            _context.Tarefas.Remove(tarefa);
        }
        public async Task SalvarAlteracoesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
