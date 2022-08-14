using Api.Domain.Dtos;
using Api.Domain.Dtos.User;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Tests.Config
{
    [CollectionDefinition(nameof(IntegrationApiTestsFixtureCollection))]
    public class IntegrationApiTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<StartupTests>> { }


    public class IntegrationTestsFixture<TStartup> : IDisposable where TStartup : class
    {

        public readonly BlogApiFactory<TStartup> Factory;
        public HttpClient Client;
        public string UsuarioToken;

        public IntegrationTestsFixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = true,
                BaseAddress = new Uri("http://localhost"),
                HandleCookies = true,
                MaxAutomaticRedirections = 7
            };

            Factory = new BlogApiFactory<TStartup>();
            Client = Factory.CreateClient(clientOptions);
        }

        public async Task RealizarLoginApi()
        {
            var userData = new LoginDto
            {
                Email = "luizbillsantos@live.com",
            };

            Client = Factory.CreateClient();

            var response = await Client.PostAsJsonAsync("api/login", userData);
            response.EnsureSuccessStatusCode();

            var apiResult = UsuarioToken = await response.Content.ReadAsStringAsync();
            var loginData = JsonConvert.DeserializeObject<LoginReturn>(apiResult);
            UsuarioToken = loginData.AccessToken;
        }
        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}
