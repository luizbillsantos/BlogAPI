using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        private DateTime? _createAt;

        public DateTime? CreateAt {
            get { return _createAt; }
            set { _createAt = (value == null ? DateTime.UtcNow : value); }
        }

        public DateTime? UpdateAt { get; set; }

    }
}
