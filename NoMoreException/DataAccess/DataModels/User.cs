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
    public record User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [DefaultValue(UserTypes.User)]
        public UserTypes UserType { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        public DateTime RegistryDate { get; set; }

        [Required]
        public bool Active { get; set; }

        public byte[] ProfileImage { get; set; }

    }
}
