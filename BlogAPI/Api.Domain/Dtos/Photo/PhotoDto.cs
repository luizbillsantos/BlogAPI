using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Dtos
{
    public class PhotoDto
    {
        public int Id { get; set; }

        public int AlbumId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string ThumbnailUrl { get; set; }
    }
}
