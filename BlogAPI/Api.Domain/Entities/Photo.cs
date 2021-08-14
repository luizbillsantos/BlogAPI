using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Domain.Entities
{
    public class Photo : BaseEntity
    {
        [Required]
        [ForeignKey("Album")]
        public int AlbumId { get; set; }

        [Required]
        [MaxLength(244)]
        public string Title { get; set; }

        [MaxLength(244)]
        public string Url { get; set; }

        [MaxLength(244)]
        public string ThumbnailUrl { get; set; }

        public virtual Album Album { get; set; }
    }
}
