using Register.API.Entities;

namespace Register.API.Repositories
{
    public interface IPeopleRepository
    {
        Task<List<People>> GetAll();

        Task<People> GetPersonById(int Id);

        Task<People> GetPersonByName(string Name);

        Task<People> NewPerson(People Person);

        Task<People> UpdatePerson(People Person);

        Task<People> DeletePerson(int Id);
    }
}
