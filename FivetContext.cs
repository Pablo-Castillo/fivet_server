using System.Reflection;
using Fivet.ZeroIce.model;
using Microsoft.EntityFrameworkCore;

namespace Fivet.Dao
{
    public class FivetContext : DbContext
    {
        // Connection to the database
        public DbSet<Persona> Personas { get; set; }

        // Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // Using SQLite
            optionsBuilder.UseSqlite("Data Source = fivet.db", options => 
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }

        // Create the ER from Entity
        protected override void OnModelCreating(ModelBuilder modelBuilder)
       {

           // Update the model
           modelBuilder.Entity<Persona>(p =>
           {
               // PK
               p.HasKey(p => p.uid);
               // Index in Email
               p.Property(p => p.email).IsRequired();
               p.HasIndex(p => p.email).IsUnique();
           });

           // Insert the data
           modelBuilder.Entity<Persona>().HasData(
               new Persona()
               {
                   uid = 1,
                   nombre = "Pablo",
                   apellido = "Castillo",
                   direccion = "LaCalle #1234",
                   email = "pablo.castillo01@alumnos.ucn.cl"
               }
           );

       }

    }
}