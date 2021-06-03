using DataAccess.DataModels.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.DataModels
{
    public record User : Base
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
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
