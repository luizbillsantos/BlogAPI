using Api.Application.Tests.Config;
using Api.Application.Tests.Fixtures;
using Api.Domain.Dtos;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Tests
{
    [Collection(nameof(IntegrationApiTestsFixtureCollection))]
    public class BlogPostTests : IClassFixture<PostTestsFixture>
    {
        private readonly IntegrationTestsFixture<StartupTests> _testsFixture;
        private readonly PostTestsFixture _postTestsFixture;
        public BlogPostTests(IntegrationTestsFixture<StartupTests> testsFixture, PostTestsFixture postTestsFixture)
        {
            _testsFixture = testsFixture;
            _postTestsFixture = postTestsFixture;
        }

        [Fact(DisplayName = "Listar Posts")]
        [Trait("Posts", "Listar")]
        public async Task Listar_PostsBlog_DeveRetornarSucesso()
        {
            //Arrange
            await _testsFixture.RealizarLoginApi();
            _testsFixture.Client.AtribuirToken(_testsFixture.UsuarioToken);

            //Act
            var postResponse = await _testsFixture.Client.GetAsync("/api/blogpost");

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, postResponse.StatusCode);
        }

        [Fact(DisplayName = "Listar Posts")]
        [Trait("Posts", "Listar")]
        public async Task Adicionar_NovoPostValido_DeveRetornarSucesso()
        {
            //Arrange
            var post = _postTestsFixture.GerarPostValido();

            await _testsFixture.RealizarLoginApi();
            _testsFixture.Client.AtribuirToken(_testsFixture.UsuarioToken);

            //Act
            var postResponse = await _testsFixture.Client.PostAsJsonAsync("/api/blogpost", post);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.Created, postResponse.StatusCode);
        }

        [Fact(DisplayName = "Listar Posts")]
        [Trait("Posts", "Listar")]
        public async Task Adicionar_NovoPostInvalido_DeveRetornarBadRequest()
        {
            //Arrange
            var post = _postTestsFixture.GerarPostInvalido();

            await _testsFixture.RealizarLoginApi();
            _testsFixture.Client.AtribuirToken(_testsFixture.UsuarioToken);

            //Act
            var postResponse = await _testsFixture.Client.PostAsJsonAsync("/api/blogpost", post);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, postResponse.StatusCode);
        }
    }
}
