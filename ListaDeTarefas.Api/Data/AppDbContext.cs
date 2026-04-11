
using ListaDeTarefas.Api.Models;    
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Api.Data
{

    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
