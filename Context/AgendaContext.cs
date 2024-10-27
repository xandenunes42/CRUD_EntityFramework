using Microsoft.EntityFrameworkCore;
using EntityFramework_CRUD.Entities;

namespace EntityFramework_CRUD.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }

        public DbSet<Contato> contatos { get; set; }
    }
}