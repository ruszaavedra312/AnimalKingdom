using Microsoft.EntityFrameworkCore;
using CRUD_Test.AnimalKindom.Models.Entities;

namespace CRUD_Test.AnimalKindom.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base (options)
        {
            
        }

        public DbSet<Animal> Animals { get; set; }
    }
}
