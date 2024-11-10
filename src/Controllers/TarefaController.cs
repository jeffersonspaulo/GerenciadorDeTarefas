using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.Controllers
{
    [ApiController]
    [Route("tarefa")]
    public class TarefaController : ControllerBase
    {
        private readonly ILogger<TarefaController> _logger;

        public TarefaController(ILogger<TarefaController> logger)
        {
            _logger = logger;
        }
    }
}
