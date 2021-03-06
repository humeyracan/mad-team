using DataAccess.DataModels.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter user name")]
        public string Username { get; set; }
        public string FullName { get; set; }
        public UserTypes UserType { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
        public DateTime RegistryDate { get; set; }
        public bool Active { get; set; }
        public byte[] ProfileImage { get; set; }
    }
}
