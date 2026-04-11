using ListaDeTarefas.Api.DTOs;
using ListaDeTarefas.Api.Enums;
using ListaDeTarefas.Api.Models;
using ListaDeTarefas.Api.Repositories;

namespace ListaDeTarefas.Api.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _repository;
        public TarefaService(ITarefaRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TarefaResponseDto>> ObterTodasTarefasAsync()
        {
            var tarefas = await _repository.ObterTodasTarefasAsync();
            return tarefas.Select(MapearParaResponseDto).ToList();
        }
        public async Task<List<TarefaResponseDto>> ObterPorStatusAsync(StatusTarefa status)
        {
            var tarefas = await _repository.ObterPorStatusAsync(status);
            return tarefas.Select(MapearParaResponseDto).ToList();
        }
        public async Task<TarefaResponseDto> ObterPorIdAsync(Guid id)
        {
            var tarefa = await _repository.ObterPorIdAsync(id);

            if (tarefa is null)
                return null;

            return MapearParaResponseDto(tarefa);
        }
        public async Task<TarefaResponseDto> CriarAsync(CriarTarefaDto dto)
        {
            var tarefa = new Tarefa
            {
                Id = Guid.NewGuid(),
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                Status = StatusTarefa.Pendente,
                DataCriacao = DateTime.UtcNow,
                DataAtualizacao = null
            };

            await _repository.AdicionarTarefaAsync(tarefa);
            await _repository.SalvarAlteracoesAsync();

            return MapearParaResponseDto(tarefa);
        }
        public async Task<bool> AtualizarAsync(Guid id, AtualizarTarefaDto dto)
        {
            var tarefa = await _repository.ObterPorIdAsync(id);

            if (tarefa is null)
                return false;

            tarefa.Titulo = dto.Titulo;
            tarefa.Descricao = dto.Descricao;
            tarefa.Status = dto.Status;
            tarefa.DataAtualizacao = DateTime.UtcNow;

            _repository.AtualizarTarefaAsync(tarefa);
            await _repository.SalvarAlteracoesAsync();

            return true;
        }
        public async Task<bool> RemoverAsync(Guid id)
        {
            var tarefa = await _repository.ObterPorIdAsync(id);

            if (tarefa is null)
                return false;

            _repository.RemoverTarefaAsync(tarefa);
            await _repository.SalvarAlteracoesAsync();

            return true;
        }
        private static TarefaResponseDto MapearParaResponseDto(Tarefa tarefa)
        {
            return new TarefaResponseDto
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Status = tarefa.Status,
                DataCriacao = tarefa.DataCriacao,
                DataAtualizacao = tarefa.DataAtualizacao
            };
        }
    }
}

