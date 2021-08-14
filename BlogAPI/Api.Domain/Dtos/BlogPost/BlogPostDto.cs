using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Dtos
{
    public class BlogPostDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

    }
}
