using GerenciadorDeTarefas.API.Services;
using Moq;
using Xunit;
using FluentAssertions;
using GerenciadorDeTarefas.API.Data.Repositories.Interfaces;
using GerenciadorDeTarefas.API.Models.Entities;
using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Models.Enums;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace GerenciadorDeTarefas.Tests
{
    public class TarefaServiceTests
    {
        private readonly Mock<ILogger<TarefaService>> _loggerMock;
        private readonly Mock<ITarefaRepository> _tarefaRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ValidationService> _validationServiceMock;
        private readonly TarefaService _tarefaService;

        public TarefaServiceTests()
        {
            _loggerMock = new Mock<ILogger<TarefaService>>();
            _tarefaRepositoryMock = new Mock<ITarefaRepository>();
            _mapperMock = new Mock<IMapper>();
            _validationServiceMock = new Mock<ValidationService>();

            _tarefaService = new TarefaService(_loggerMock.Object, _tarefaRepositoryMock.Object, _mapperMock.Object, _validationServiceMock.Object);
        }

        [Fact]
        public async Task QuandoCriarTarefa_UsandoDto_DeveChamarInsertAsyncNoRepositorio()
        {
            // Arrange
            var tarefaCreateDto = new TarefaCreateDto
            {
                UsuarioId = 1,
                ProjetoId = 2,
                Titulo = "Testar Tarefa",
                Descricao = "Descrição da tarefa",
                DataVencimento = DateTime.Now.AddDays(5),
                TarefaStatus = TarefaStatus.Pendente,
                Prioridade = Prioridade.Alta,
                Comentario = "Comentário de teste"
            };

            var tarefa = new Tarefa
            {
                Id = 1,
                ProjetoId = 2,
                Titulo = "Testar Tarefa",
                Descricao = "Descrição da tarefa",
                DataVencimento = DateTime.Now.AddDays(5),
                TarefaStatus = TarefaStatus.Pendente,
                Prioridade = Prioridade.Alta
            };

            _mapperMock.Setup(m => m.Map<Tarefa>(It.IsAny<TarefaCreateDto>())).Returns(tarefa);

            _tarefaRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Tarefa>())).ReturnsAsync(tarefa);

            // Act
            var resultado = await _tarefaService.InsertAsync(tarefaCreateDto);

            // Assert
            _tarefaRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Tarefa>()), Times.Once);

            // Verifica se o resultado não é nulo e corresponde à tarefa criada
            resultado.Should().NotBeNull();
            resultado.Data.Should().Be(tarefaCreateDto);
        }
    }
}
