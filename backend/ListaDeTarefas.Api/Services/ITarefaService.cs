using ListaDeTarefas.Api.DTOs;
using ListaDeTarefas.Api.Enums;

namespace ListaDeTarefas.Api.Services
{
    public interface ITarefaService
    {
        Task<List<TarefaResponseDto>> ObterTodasTarefasAsync();
        Task<List<TarefaResponseDto>> ObterPorStatusAsync(StatusTarefa status);
        Task<TarefaResponseDto> ObterPorIdAsync(Guid id);
        Task<TarefaResponseDto> CriarAsync(CriarTarefaDto dto);
        Task<bool> AtualizarAsync(Guid id, AtualizarTarefaDto dto);
        Task<bool> RemoverAsync(Guid id);
    }
}
