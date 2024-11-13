using GerenciadorDeTarefas.API.Services;
using Moq;
using FluentAssertions;
using GerenciadorDeTarefas.API.Data.Repositories.Interfaces;
using GerenciadorDeTarefas.API.Models.Entities;
using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Models.Enums;
using AutoMapper;
using Microsoft.Extensions.Logging;
using GerenciadorDeTarefas.API.Utils;
using GerenciadorDeTarefas.API.Services.Interfaces;

namespace GerenciadorDeTarefas.Tests
{
    public class TarefaServiceTests
    {
        private readonly Mock<ILogger<TarefaService>> _loggerMock;
        private readonly Mock<ITarefaRepository> _tarefaRepositoryMock; 
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IValidationService> _validationServiceMock;
        private readonly TarefaService _tarefaService;

        public TarefaServiceTests()
        {
            _loggerMock = new Mock<ILogger<TarefaService>>();
            _tarefaRepositoryMock = new Mock<ITarefaRepository>();
            _mapperMock = new Mock<IMapper>();
            _validationServiceMock = new Mock<IValidationService>();

            _tarefaService = new TarefaService(_loggerMock.Object, _tarefaRepositoryMock.Object, _mapperMock.Object, _validationServiceMock.Object);
        }

        [Fact]
        public async Task InsertAsync_DeveChamarInsertAsyncNoRepositorioEAdicionarHistorico_QuandoCriarTarefaComDtoValido()
        {
            // Arrange
            var tarefaCreateDto = new TarefaCreateDto
            {
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

            var usuarioId = "1";

            _mapperMock.Setup(m => m.Map<Tarefa>(tarefaCreateDto)).Returns(tarefa);
            _tarefaRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Tarefa>())).ReturnsAsync(tarefa);
            _tarefaRepositoryMock.Setup(r => r.AddHistorico(It.IsAny<Tarefa>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                                 .Callback<Tarefa, string, string, string>((t, u, c, n) => Console.WriteLine($"AddHistorico chamado para Tarefa ID {t.Id}"))
                                 .Returns(Task.CompletedTask);
            _validationServiceMock.Setup(v => v.Validate(It.IsAny<TarefaCreateDto>())).Returns(Result.Success());

            // Act
            var resultado = await _tarefaService.InsertAsync(usuarioId, tarefaCreateDto);

            // Assert
            _tarefaRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Tarefa>()), Times.Once);
            _tarefaRepositoryMock.Verify(r => r.AddHistorico(It.IsAny<Tarefa>(), usuarioId, tarefaCreateDto.Comentario, "InsertAsync"), Times.Once);

            resultado.Should().NotBeNull();
            resultado.IsSuccess.Should().BeTrue();
            resultado.Data.Should().Be(tarefa);
        }


        [Fact]
        public async Task GetAllAsync_DeveRetornarResultadoDeSucessoEDados_QuandoTarefasExistirem()
        {
            // Arrange
            var tarefas = new List<Tarefa> { new Tarefa { Id = 1, Titulo = "Tarefa 1" } };
            _tarefaRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(tarefas);

            // Act
            var resultado = await _tarefaService.GetAllAsync();

            // Assert
            resultado.IsSuccess.Should().BeTrue();
            resultado.Data.Should().BeEquivalentTo(tarefas);
        }

        [Fact]
        public async Task GetByIdAsync_DeveRetornarResultadoDeSucessoEDados_QuandoTarefaExistir()
        {
            // Arrange
            var tarefa = new Tarefa { Id = 1, Titulo = "Tarefa 1" };
            _tarefaRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(tarefa);

            // Act
            var resultado = await _tarefaService.GetByIdAsync(1);

            // Assert
            resultado.IsSuccess.Should().BeTrue();
            resultado.Data.Should().Be(tarefa);
        }

        [Fact]
        public async Task GetByIdAsync_DeveRetornarFalha_QuandoTarefaNaoExistir()
        {
            // Arrange
            _tarefaRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Tarefa)null);

            // Act
            var resultado = await _tarefaService.GetByIdAsync(1);

            // Assert
            resultado.IsSuccess.Should().BeFalse();
            resultado.ErrorMessage.Should().Be("Nenhuma tarefa encontrada com o ID 1.");
        }

        [Fact]
        public async Task UpdateAsync_DeveChamarUpdateAsyncNoRepositorioEAdicionarHistorico_QuandoTarefaExistir()
        {
            // Arrange
            var tarefa = new Tarefa { Id = 1, Titulo = "Tarefa 1" };
            var tarefaDto = new TarefaUpdateDto
            {
                Titulo = "Tarefa Atualizada",
                Comentario = "Comentário de atualização"
            };

            var usuarioId = "1";

            _tarefaRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(tarefa);
            _validationServiceMock.Setup(v => v.Validate(tarefaDto)).Returns(Result.Success());

            // Act
            var resultado = await _tarefaService.UpdateAsync(1, usuarioId, tarefaDto);

            // Assert
            _tarefaRepositoryMock.Verify(r => r.UpdateAsync(It.IsAny<Tarefa>()), Times.Once);
            _tarefaRepositoryMock.Verify(r => r.AddHistorico(tarefa, usuarioId, tarefaDto.Comentario, "UpdateAsync"), Times.Once);
            resultado.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task UpdateAsync_DeveRetornarFalha_QuandoTarefaNaoExistir()
        {
            // Arrange
            _tarefaRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Tarefa)null);

            var usuarioId = "1";

            // Act
            var resultado = await _tarefaService.UpdateAsync(1, usuarioId, new TarefaUpdateDto());

            // Assert
            resultado.IsSuccess.Should().BeFalse();
            resultado.ErrorMessage.Should().Be("Nenhuma tarefa encontrada com o ID 1.");
        }

        [Fact]
        public async Task DeleteAsync_DeveChamarDeleteAsyncNoRepositorio_QuandoIdValido()
        {
            // Arrange
            var tarefa = new Tarefa { Id = 1, Titulo = "Tarefa Teste" };

            _tarefaRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(tarefa);

            _tarefaRepositoryMock.Setup(r => r.DeleteAsync(1)).Returns(Task.CompletedTask);

            // Act
            var resultado = await _tarefaService.DeleteAsync(1);

            // Assert
            _tarefaRepositoryMock.Verify(r => r.DeleteAsync(1), Times.Once);  
            resultado.IsSuccess.Should().BeTrue(); 
        }

        [Fact]
        public async Task DeleteAsync_DeveRetornarFalha_QuandoOcorreErroNoDelete()
        {
            // Arrange
            var tarefa = new Tarefa { Id = 2, Titulo = "Tarefa Teste" };

            _tarefaRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(tarefa);

            _tarefaRepositoryMock.Setup(r => r.DeleteAsync(It.IsAny<int>())).ThrowsAsync(new Exception("Erro ao deletar"));

            // Act
            var resultado = await _tarefaService.DeleteAsync(2);

            // Assert
            resultado.IsSuccess.Should().BeFalse();
            resultado.ErrorMessage.Should().Be("Ocorreu um erro durante a requisição."); 
        }
    }
}
