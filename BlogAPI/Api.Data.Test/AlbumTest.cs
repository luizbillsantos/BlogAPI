using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Data.Test
{
    public class AlbumTest : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public AlbumTest(DbTeste dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Add, Get and GetAll")]
        [Trait("Album", "Data")]
        public async Task AlbumDataTest()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                AlbumImplementation _repositorio = new AlbumImplementation(context);

                AlbumEntity _entity = new AlbumEntity
                {
                    Title = Faker.Lorem.Sentence(1),
                    UserId = 1,
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Title, _registroCriado.Title);

                var _registroExiste = await _repositorio.ExistAsync(_registroCriado.Id);

                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorio.SelectAsync(_registroCriado.Id);
                Assert.NotNull(_registroSelecionado);

                var _todosRegistros = await _repositorio.SelectAsync();

                Assert.True(_todosRegistros.Any());
            }
        }
    }
}
