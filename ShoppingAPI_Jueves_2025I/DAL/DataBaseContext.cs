using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Jueves_2025I.DAL.Entities;

namespace ShoppingAPI_Jueves_2025I.DAL
{
    public class DataBaseContext : DbContext
    {
        // Así me conecto a la BD por medio de este contructor
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }

        // Este metodo es propio de EF CORE y me sirve para configurar unos indices de cada campo de una tabla en BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique(); // Aquí creo un índice del campo Name para la tabla Countries

        }

        #region DbSets

        public DbSet<Country> Countries { get; set; }

        #endregion
    }
}
