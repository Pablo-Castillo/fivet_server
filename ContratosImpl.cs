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
            throw new System.NotImplementedException();
        }

        public override Ficha crearFicha(Ficha ficha, Current current)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public override Persona obtenerPersona(string rut, Current current)
        {
            throw new System.NotImplementedException();
        }
        
    }
}