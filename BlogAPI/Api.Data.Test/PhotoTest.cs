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
    public class PhotoTest : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public PhotoTest(DbTeste dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Add, Get and GetAll")]
        [Trait("Photo", "Data")]
        public async Task PhotoDataTest()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                PhotoImplementation _repositorio = new PhotoImplementation(context);
                AlbumImplementation _albumRepositorio = new AlbumImplementation(context);

                AlbumEntity _albumEntity = new AlbumEntity
                {
                    Title = Faker.Lorem.Sentence(1),
                    UserId = 1,
                };

                var _albumRegistroCriado = await _albumRepositorio.InsertAsync(_albumEntity);
                Assert.NotNull(_albumRegistroCriado);

                PhotoEntity _entity = new PhotoEntity
                {
                    Title = Faker.Lorem.Sentence(1),
                    Url = Faker.Internet.DomainName(),
                    ThumbnailUrl = Faker.Internet.DomainName(),
                    AlbumId = _albumRegistroCriado.Id,
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
