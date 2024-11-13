using FluentAssertions;
using GerenciadorDeTarefas.API.Data.Repositories.Interfaces;
using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace GerenciadorDeTarefas.Tests
{
    public class RelatorioServiceTests
    {
        private readonly Mock<ILogger<RelatorioService>> _loggerMock;
        private readonly Mock<IRelatorioRepository> _relatorioRepositoryMock;
        private readonly Mock<ValidationService> _validationServiceMock;
        private readonly RelatorioService _relatorioService;

        public RelatorioServiceTests()
        {
            _loggerMock = new Mock<ILogger<RelatorioService>>();
            _relatorioRepositoryMock = new Mock<IRelatorioRepository>();
            _validationServiceMock = new Mock<ValidationService>();

            _relatorioService = new RelatorioService(_loggerMock.Object, _relatorioRepositoryMock.Object, _validationServiceMock.Object);
        }

        [Fact]
        public async Task CalcularMediaTarefasConcluidasPeriodoAsync_DeveRetornarSucesso_QuandoDadosValidos()
        {
            // Arrange
            var dataInicio = new DateTime(2024, 01, 01);
            var dataFim = new DateTime(2024, 01, 31);

            var relatoriosEsperados = new List<RelatorioUsuarioMediaDto>
            {
                new RelatorioUsuarioMediaDto { UsuarioId = "1", Media = 5 },
                new RelatorioUsuarioMediaDto { UsuarioId = "2", Media = 3 }
            };

            _relatorioRepositoryMock
                .Setup(r => r.CalcularMediaTarefasConcluidasPeriodoAsync(dataInicio, dataFim))
                .ReturnsAsync(relatoriosEsperados);

            // Act
            var resultado = await _relatorioService.CalcularMediaTarefasConcluidasPeriodoAsync(dataInicio, dataFim);

            // Assert
            resultado.IsSuccess.Should().BeTrue();
            resultado.Data.Should().BeEquivalentTo(relatoriosEsperados);
            _relatorioRepositoryMock.Verify(r => r.CalcularMediaTarefasConcluidasPeriodoAsync(dataInicio, dataFim), Times.Once);
        }

        [Fact]
        public async Task CalcularMediaTarefasConcluidasPeriodoAsync_DeveRetornarErro_QuandoRepositoryFalhar()
        {
            // Arrange
            var dataInicio = new DateTime(2024, 01, 01);
            var dataFim = new DateTime(2024, 01, 31);

            _relatorioRepositoryMock
                .Setup(r => r.CalcularMediaTarefasConcluidasPeriodoAsync(dataInicio, dataFim))
                .ThrowsAsync(new Exception("Erro inesperado"));

            // Act
            var resultado = await _relatorioService.CalcularMediaTarefasConcluidasPeriodoAsync(dataInicio, dataFim);

            // Assert
            resultado.IsSuccess.Should().BeFalse();
            resultado.ErrorMessage.Should().Be("Ocorreu um erro durante a requisição.");
            _relatorioRepositoryMock.Verify(r => r.CalcularMediaTarefasConcluidasPeriodoAsync(dataInicio, dataFim), Times.Once);
        }
    }
}
