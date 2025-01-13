using ControleFinanceiro.Application.DTOs;
using ControleFinanceiro.Application.Services;
using ControleFinanceiro.Core.Entities;
using ControleFinanceiro.Core.Interfaces;
using Moq;

namespace ControleFinanceiro.Testes
{
    public class UserServiceTeste
    {
        [Fact]
        public async Task UsuarioService_Deve_Retornar_Nulo_Quando_Usuario_Nao_Existe_No_Banco()
        {
            var usuarioRepositoryMock = new Moq.Mock<IUsuarioRepository>();

            usuarioRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Usuario?) null);

            var usuarioService = new UsuarioService(usuarioRepositoryMock.Object);

            var user = await usuarioService.GetUsuarioByIdAsync(1);

            Assert.Null(user);
        } 
        
        [Fact]
        public async Task UsuarioService_Deve_Retornar_Ao_Encontrar_Usuario()
        {
            var usuarioRepositoryMock = new Moq.Mock<IUsuarioRepository>();

            usuarioRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Usuario?) new Usuario(1, "Arthur", "arthur@email.com"));

            var usuarioService = new UsuarioService(usuarioRepositoryMock.Object);

            var user = await usuarioService.GetUsuarioByIdAsync(1);

            Assert.NotNull(user);
            Assert.IsType<UsuarioDTO>(user);
        }
    }
}