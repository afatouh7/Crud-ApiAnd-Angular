using AssApi.Models;

namespace AssApi.Dtos
{
    public class GetPersonDto
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        public int Age { get; set; }

        public Address Address { get; set; }
    }
}
