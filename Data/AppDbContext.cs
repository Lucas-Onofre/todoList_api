using Microsoft.EntityFrameworkCore;
using todoListAPI.Models;

namespace todoListAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}