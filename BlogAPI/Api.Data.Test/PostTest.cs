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
    public class PostTest : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public PostTest(DbTeste dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Add, Get and GetAll")]
        [Trait("BlogPost", "Data")]
        public async Task PostDataTest()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                BlogPostImplementation _repositorio = new BlogPostImplementation(context);
                BlogPostEntity _entity = new BlogPostEntity
                {
                    Body = String.Join(",",Faker.Lorem.Paragraphs(5)),
                    Title = Faker.Name.FullName(),
                    UserId = 1
                    
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Body, _registroCriado.Body);
                Assert.Equal(_entity.Title, _registroCriado.Title);

                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Body, _registroCriado.Body);
                Assert.Equal(_entity.Title, _registroCriado.Title);

                var _registroExiste = await _repositorio.ExistAsync(_registroCriado.Id);

                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorio.SelectAsync(_registroCriado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_entity.Body, _registroSelecionado.Body);
                Assert.Equal(_entity.Title, _registroSelecionado.Title);

                var _todosRegistros = await _repositorio.SelectAsync();

                Assert.True(_todosRegistros.Any());

            }
        }
    }
}
