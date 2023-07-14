using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Services;
using System.ComponentModel;

namespace WebApplication1.Models
{
    public class HomeStay
    {
        public int Id { get; set; }
        public string Property_Name { get; set; }
        public string Property_Address { get; set; }
        public string Property_Type { get; set; }
        public string Property_Contact { get; set; }
        public string? NoofRooms { get; set; }
        //[Column(TypeName="byte[,]")]
        //[TypeConverter(typeof(ByteArrayConverter))]
        public List<IFormFile> Pics { get; set; }
        public string? UserName { get; set; }
        [ForeignKey("UserName")]
        public User? User { get; set; }
    }
}