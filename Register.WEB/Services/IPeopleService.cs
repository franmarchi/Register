using Register.API.Entities;

namespace Register.WEB.Services
{
    public interface IPeopleService
    {
        Task<IEnumerable<People>> GetAll();

        Task<People> GetPersonByName(string Name);

        Task<People> NewPerson(People Person);

        Task<People> UpdatePerson(People Person);

        Task DeletePerson(int Id);
    }
}
