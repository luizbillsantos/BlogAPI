using Api.Application.Tests.Config;
using Api.Domain.Dtos;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Tests.Fixtures
{

    public class PostTestsFixture
    {

        public Faker _faker;

        public PostTestsFixture()
        {
            _faker = new Faker("pt_BR");
        }

        public BlogPostDtoCreate GerarPostValido()
        {
            return new BlogPostDtoCreate
            {
                Title = _faker.Lorem.Sentence(),
                Body = _faker.Lorem.Text()
            };
        }

        public BlogPostDtoCreate GerarPostInvalido()
        {
            return new BlogPostDtoCreate
            {
                Title = _faker.Lorem.Sentence(),
            };
        }

        public void Dispose()
        {
        }
    }
}
