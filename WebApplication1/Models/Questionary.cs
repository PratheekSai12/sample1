using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Questionary
    {
        [Key]
        public int Id { get; set; }
        public string About { get; set; }
        public string Passionate { get; set; }
        public string Hobbies { get; set; }
        public string Accomplishment { get; set; }
        public string Life { get; set; }
        public string Personal_Expertise { get; set; }
        public string Professional_Expertise { get; set; }
        public string Whats_Life { get; set; }
        public string Travel { get; set; }
        public string Offer { get; set; }
        public string Kindof_Guests { get; set; }
        public string Greatest_Impact { get; set; }
        public string Cherished_Memories { get; set; }
        public string Pictures { get; set; }
        public string Journer_Destination { get; set; }
        public string? UserName { get; set; }
        [ForeignKey("UserName")]
        public User? User { get; set; }
    }
}