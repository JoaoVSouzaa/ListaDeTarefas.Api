using ListaDeTarefas.Api.Enums;

namespace ListaDeTarefas.Api.DTOs
{
    public class AtualizarTarefaDto
    {
        public string Titulo { get; set; } = string.Empty; 
        public string Descricao { get; set; } = string.Empty;
        public StatusTarefa Status { get; set; }
    }
}
