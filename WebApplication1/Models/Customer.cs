using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public byte[] ProfilePic { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        [ForeignKey("UserName")]
        public User? User { get; set; }
    }
}