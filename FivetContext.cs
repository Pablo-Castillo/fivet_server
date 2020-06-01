using System.Reflection;
using Fivet.ZeroIce.model;
using Microsoft.EntityFrameworkCore;

namespace Fivet.Dao
{
    public class FivetContext : DbContext
    {
        // Connection to the database
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<Control> Controles { get; set; }
        public DbSet<Examen> Examenes { get; set; }

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
               // Index in personal data
               p.Property(p => p.rut).IsRequired();
               p.HasIndex(p => p.rut).IsUnique();
               // Personal data
               p.Property(p => p.nombre).IsRequired();
               p.Property(p => p.apellido).IsRequired();
               p.Property(p => p.direccion).IsRequired();

           });

           // Insert the data
           modelBuilder.Entity<Persona>().HasData(
               new Persona()
               {
                   uid = 1,
                   rut = "182335622",
                   nombre = "Pablo",
                   apellido = "Castillo",
                   direccion = "LaCalle #1234",
                   email = "pablo.castillo01@alumnos.ucn.cl"
               }
           );

           modelBuilder.Entity<Control>(c =>
            {
                c.HasKey(c=> c.uid);
                c.Property(c=> c.fecha).IsRequired();
                c.Property(c=> c.temperatura).IsRequired();
                c.Property(c=> c.peso).IsRequired();
                c.Property(c=> c.altura).IsRequired();
                c.Property(c=> c.diagnostico).IsRequired();
                c.Property(c=> c.veterinario).IsRequired();
            });

            modelBuilder.Entity<Control>().HasData(
                new Control()
                {
                    uid = 1,
                    fecha ="30/05/2019",
                    temperatura = 41,
                    peso= 30f,
                    altura= 100,
                    diagnostico="Fiebre Elevada",
                    veterinario="Carlos Vidal Pinto"
                }
            );

            modelBuilder.Entity<Ficha>(f =>
            {
                f.HasKey(f=> f.uid);
                f.Property(f=> f.nFicha).IsRequired();
                f.Property(f=> f.nombPaciente).IsRequired();
                f.Property(f=> f.especie).IsRequired();
                f.Property(f=> f.nacimiento).IsRequired();
                f.Property(f=> f.sexo).IsRequired();
                f.Property(f=> f.color).IsRequired();
                f.Property(f=> f.tipoPaciente).IsRequired();
                
            });

            modelBuilder.Entity<Ficha>().HasData(
                new Ficha()
                {
                    uid = 1,
                    nFicha =1,
                    nombPaciente = "Snowball",
                    especie ="Perro",
                    nacimiento ="12/12/2012",
                    raza ="Corgi",
                    sexo = Sexo.MACHO,
                    color = "Cafe",
                    tipoPaciente = tipoPaciente.EXTERNO,
                }
            );

            modelBuilder.Entity<Examen>(e =>
            {
                e.HasKey(e=> e.uid);
                e.Property(e=> e.nomExamen).IsRequired();
                e.Property(e=> e.feExamen).IsRequired();
            });

            modelBuilder.Entity<Examen>().HasData(
                new Examen()
                {
                    uid = 1,
                    nomExamen ="Radiografia",
                    feExamen = "24/09/2019",
                }
            );

       }

    }
}