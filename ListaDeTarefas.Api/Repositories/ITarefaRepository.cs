using ListaDeTarefas.Api.Models;
using ListaDeTarefas.Api.Enums; 

namespace ListaDeTarefas.Api.Repositories
{
    public interface ITarefaRepository
    {
        Task<List<Tarefa>> ObterTodasTarefasAsync();
        Task<List<Tarefa>> ObterPorStatusAsync(StatusTarefa status);
        Task<Tarefa> ObterPorIdAsync(Guid id);  
        Task AdicionarTarefaAsync(Tarefa tarefa);
        void AtualizarTarefaAsync(Tarefa tarefa);
        void RemoverTarefaAsync(Tarefa tarefa);
        Task SalvarAlteracoesAsync();
    }
}
