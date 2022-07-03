using System.ComponentModel.DataAnnotations;

namespace AssApi.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public int Age { get; set; }
       
        public Address Address { get; set; }
    }
}
