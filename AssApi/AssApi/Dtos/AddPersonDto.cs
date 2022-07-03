using AssApi.Models;

namespace AssApi.Dtos
{
    public class AddPersonDto
    {
        
        public string Name { get; set; }
        public int Age { get; set; }

        public Address Address { get; set; }
    }
}
