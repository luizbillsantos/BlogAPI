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
    public class UserTest : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public UserTest(DbTeste dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Add, Get and GetAll")]
        [Trait("User", "Data")]
        public async Task UserDataTest()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repositorio = new UserImplementation(context);

                UserEntity _entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName(),
                    Phone = Faker.Phone.Number(),
                    WebSite = Faker.Internet.DomainName(),
                    UserName = Faker.Internet.UserName(),
                    Company = new CompanyEntity()
                    {
                        Name = Faker.Company.Name(),
                        CatchPhrase = Faker.Company.CatchPhrase(),
                        Bs = Faker.Company.BS(),
                    },
                    Address = new AddressEntity()
                    {
                        City = Faker.Address.City(),
                        Street = Faker.Address.StreetName(),
                        Suite = Faker.Address.StreetAddress(),
                        ZipCode = Faker.Address.ZipCode(),
                        Geo = new GeoEntity()
                        {
                            Lat = -58.855555M,
                            Lng = -96.785555M
                        },
                    }


                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.Equal(_entity.Phone, _registroCriado.Phone);
                Assert.Equal(_entity.WebSite, _registroCriado.WebSite);
                Assert.Equal(_entity.UserName, _registroCriado.UserName);

                Assert.NotNull(_registroCriado.Address);
                Assert.NotNull(_registroCriado.Company);
                Assert.NotNull(_registroCriado.Address.Geo);

                Assert.Equal(_entity.Address.City, _registroCriado.Address.City);
                Assert.Equal(_entity.Address.Street, _registroCriado.Address.Street);
                Assert.Equal(_entity.Address.Suite, _registroCriado.Address.Suite);
                Assert.Equal(_entity.Address.ZipCode, _registroCriado.Address.ZipCode);
                Assert.Equal(_entity.Address.Geo.Lat, _registroCriado.Address.Geo.Lat);
                Assert.Equal(_entity.Address.Geo.Lng, _registroCriado.Address.Geo.Lng);

                Assert.Equal(_entity.Company.Name, _registroCriado.Company.Name);
                Assert.Equal(_entity.Company.CatchPhrase, _registroCriado.Company.CatchPhrase);
                Assert.Equal(_entity.Company.Bs, _registroCriado.Company.Bs);

                var _registroExiste = await _repositorio.ExistAsync(_registroCriado.Id);

                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorio.SelectAsync(_registroCriado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_entity.Name, _registroSelecionado.Name);
                Assert.Equal(_entity.Email, _registroSelecionado.Email);


                var _todosRegistros = await _repositorio.SelectAsync();

                Assert.True(_todosRegistros.Any());

                var _usuarioPadrao = await _repositorio.FindByLogin("luizbillsantos@live.com");

                Assert.NotNull(_usuarioPadrao);
                Assert.Equal("luizbillsantos@live.com", _usuarioPadrao.Email);
            }
        }

    }
}
