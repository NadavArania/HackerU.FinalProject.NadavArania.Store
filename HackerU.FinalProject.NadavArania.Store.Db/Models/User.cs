using HackerU.FinalProject.NadavArania.Store.Db.ITypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackerU.FinalProject.NadavArania.Store.Db.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
        public UType Type { get; set; }
        public List<Order> Orders { get; set; }
        [NotMapped]
        public bool Logged { get; set; }
    }
}
