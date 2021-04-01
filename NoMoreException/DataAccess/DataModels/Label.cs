using DataAccess.DataModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataModels
{
    public record Label
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Text { get; set; }
    }
}
