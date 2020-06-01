using Fivet.Dao;
using Fivet.ZeroIce.model;
using Ice;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Fivet.ZeroIce
{
    // The implementation of the Contratos
    public class ContratosImpl : ContratosDisp_
    {
        // The Logger
        private readonly ILogger<ContratosImpl> _logger;

        // The Provider of DbContext
        private readonly IServiceScopeFactory _serviceScopeFactory;

        // The constructor
        public ContratosImpl(ILogger<ContratosImpl> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _logger.LogDebug("Building the ContratosImpl ..");
            _serviceScopeFactory = serviceScopeFactory;

            // Create the database
            _logger.LogInformation("Creating the Database ..");
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                FivetContext fc = scope.ServiceProvider.GetService<FivetContext>();
                fc.Database.EnsureCreated();
                fc.SaveChanges();
            }
            _logger.LogDebug("Done.");            
        }

        public override Ficha obtenerFicha(int numero, Current current)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                FivetContext fc = scope.ServiceProvider.GetService<FivetContext>();
                Ficha ficha = fc.Fichas.Find(numero);
                fc.SaveChanges();
                return ficha;
            }
        }

        public override Ficha crearFicha(Ficha ficha, Current current)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                FivetContext fc = scope.ServiceProvider.GetService<FivetContext>();
                fc.Fichas.Add(ficha);
                fc.SaveChanges();
                return ficha;
            }
        }

        public override Persona crearPersona(Persona persona, Current current)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                FivetContext fc = scope.ServiceProvider.GetService<FivetContext>();
                fc.Personas.Add(persona);
                fc.SaveChanges();
                return persona;
            }
        }

        public override Control crearControl(int numFicha, Control control, Current current)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                FivetContext fc = scope.ServiceProvider.GetService<FivetContext>();
                fc.Controles.Add(control);
                fc.SaveChanges();
                return control;
            }
        }

        public override Persona obtenerPersona(string rut, Current current)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                FivetContext fc = scope.ServiceProvider.GetService<FivetContext>();
                Persona persona = fc.Personas.Find(rut);
                fc.SaveChanges();
                return persona;
            }
        }
        
    }
}