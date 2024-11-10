using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.Controllers
{
    [ApiController]
    [Route("projeto")]
    public class ProjetoController : ControllerBase
    {
        private readonly ILogger<ProjetoController> _logger;

        public ProjetoController(ILogger<ProjetoController> logger)
        {
            _logger = logger;
        }
    }
}
