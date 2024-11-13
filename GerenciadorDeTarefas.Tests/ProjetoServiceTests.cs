using AutoMapper;
using GerenciadorDeTarefas.API.Data.Repositories.Interfaces;
using GerenciadorDeTarefas.API.Services.Interfaces;
using GerenciadorDeTarefas.API.Services;
using Microsoft.Extensions.Logging;
using Moq;
using FluentAssertions;
using GerenciadorDeTarefas.API.Models.Entities;
using System.Linq.Expressions;

namespace GerenciadorDeTarefas.Tests
{
    public class ProjetoServiceTests
    {
        private readonly Mock<ILogger<ProjetoService>> _loggerMock;
        private readonly Mock<IProjetoRepository> _projetoRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ValidationService> _validationServiceMock;
        private readonly ProjetoService _projetoService;

        public ProjetoServiceTests()
        {
            _loggerMock = new Mock<ILogger<ProjetoService>>();
            _projetoRepositoryMock = new Mock<IProjetoRepository>();
            _mapperMock = new Mock<IMapper>();
            _validationServiceMock = new Mock<ValidationService>(MockBehavior.Loose);

            _projetoService = new ProjetoService(_loggerMock.Object, _projetoRepositoryMock.Object, _mapperMock.Object, _validationServiceMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_DeveRetornarProjetos_QuandoExistiremProjetos()
        {
            // Arrange
            var projetos = new List<Projeto>
            {
                new Projeto { Id = 1, Titulo = "Projeto 1" },
                new Projeto { Id = 250, Titulo = "Projeto 2" }
            };

            _projetoRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(projetos); 

            // Act
            var resultado = await _projetoService.GetAllAsync();

            // Assert
            resultado.IsSuccess.Should().BeTrue(); 
            resultado.Data.Should().BeEquivalentTo(projetos);
        }

        [Fact]
        public async Task GetAllAsync_DeveRetornarFalha_QuandoNaoExistiremProjetos()
        {
            // Arrange
            _projetoRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync((List<Projeto>)null);

            // Act
            var resultado = await _projetoService.GetAllAsync();

            // Assert
            resultado.IsSuccess.Should().BeFalse(); 
            resultado.ErrorMessage.Should().Be("Nenhum projeto encontrado."); 
        }

        [Fact]
        public async Task GetByIdAsync_DeveRetornarProjeto_QuandoProjetoExistir()
        {
            // Arrange
            var projeto = new Projeto { Id = 2, Titulo = "Projeto Teste 1" };
                        
            _projetoRepositoryMock
                .Setup(r => r.GetByIdWithIncludesAsync(2, It.IsAny<Expression<Func<Projeto, object>>>()))
                .ReturnsAsync(projeto); 

            // Act
            var resultado = await _projetoService.GetByIdAsync(2);

            // Assert
            resultado.IsSuccess.Should().BeTrue();
            resultado.Data.Should().Be(projeto); 
        }

        [Fact]
        public async Task GetByIdAsync_DeveRetornarFalha_QuandoProjetoNaoExistir()
        {
            // Arrange
            _projetoRepositoryMock.Setup(r => r.GetByIdWithIncludesAsync(It.IsAny<int>(), It.IsAny<Expression<Func<Projeto, object>>>())).ReturnsAsync(new Projeto { Tarefas = new List<Tarefa> { new Tarefa() } });

            // Act
            var resultado = await _projetoService.GetByIdAsync(1);

            // Assert
            resultado.IsSuccess.Should().BeFalse();
            resultado.ErrorMessage.Should().Be("Nenhum projeto encontrado com o ID 1."); 
        }


    }
}
