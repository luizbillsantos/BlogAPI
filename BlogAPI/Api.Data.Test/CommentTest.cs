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
    public class CommentTest : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public CommentTest(DbTeste dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Add, Get and GetAll")]
        [Trait("Comment", "Data")]
        public async Task CommentDataTest()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                BlogPostImplementation _blogRepositorio = new BlogPostImplementation(context);
                BlogPostEntity _blogEntity = new BlogPostEntity
                {
                    Body = String.Join(",", Faker.Lorem.Paragraphs(5)),
                    Title = Faker.Name.FullName(),
                    UserId = 1

                };

                var _blogRegistroCriado = await _blogRepositorio.InsertAsync(_blogEntity);

                Assert.NotNull(_blogRegistroCriado);

                CommentImplementation _repositorio = new CommentImplementation(context);

                CommentEntity _entity = new CommentEntity
                {
                    Body = Faker.Lorem.Sentence(1),
                    UserId = 1,
                    Email = Faker.Internet.Email(),
                    Name = Faker.Lorem.Sentence(1),
                    PostId = _blogRegistroCriado.Id,
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.Equal(_entity.Body, _registroCriado.Body);

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
