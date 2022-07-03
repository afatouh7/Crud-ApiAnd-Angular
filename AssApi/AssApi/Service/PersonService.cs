using AssApi.Data;
using AssApi.Dtos;
using AssApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssApi.Service
{
    public class PersonService : IPersonService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PersonService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetPersonDto>>> AddPerson(AddPersonDto person)
        { 
            ServiceResponse<List<GetPersonDto>> serviceResponse = new ServiceResponse<List<GetPersonDto>>();
            Person person1 = _mapper.Map<Person>(person);
            await _context.Persons.AddAsync(person1);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.Persons.Select(c=>_mapper.Map<GetPersonDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPersonDto>>> DeletePerson(int id)
        {
            ServiceResponse<List<GetPersonDto>> serviceResponse = new ServiceResponse<List<GetPersonDto>>();
            try
            {
                Person person = await _context.Persons.FirstAsync(c => c.Id ==id);
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
                serviceResponse.Data = (_context.Persons.Select(c => _mapper.Map<GetPersonDto>(c))).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPersonDto>> EditPerson(EditPersonDto editPersonDto)
        {
            ServiceResponse<GetPersonDto> serviceResponse = new ServiceResponse<GetPersonDto>();
            try
            {
                Person person = await _context.Persons.FirstOrDefaultAsync(c => c.Id == editPersonDto.Id); 
                person.Name= editPersonDto.Name;
                person.Age = editPersonDto.Age;
                person.Address=editPersonDto.Address;
                _context.Persons.Update(person);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false; 
                serviceResponse.Message=ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPersonDto>>> GetAllPerson()
        {
            ServiceResponse<List<GetPersonDto>> serviceResponse = new ServiceResponse<List<GetPersonDto>>();
            List<Person> dbperson = await _context.Persons.Include(x=>x.Address).ToListAsync();
            
            serviceResponse.Data = (dbperson.Select(c=>_mapper.Map<GetPersonDto>(c))).ToList();
            return serviceResponse;
        }
    }
}
