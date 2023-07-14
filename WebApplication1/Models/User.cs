using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? Key { get; set; }
        public string Role { get; set; }
        public string Status{get; set;}
        }
}
