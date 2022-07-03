
using AssApi.Dtos;
using AssApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssApi.Service
{
    public interface IPersonService
    {
        Task<ServiceResponse<List<GetPersonDto>>> GetAllPerson();
        Task<ServiceResponse<List<GetPersonDto>>> AddPerson(AddPersonDto person);
        Task<ServiceResponse<GetPersonDto>> EditPerson(EditPersonDto editPersonDto); 
        Task<ServiceResponse<List<GetPersonDto>>> DeletePerson(int id);   
    }
}
