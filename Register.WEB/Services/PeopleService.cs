using Register.API.Entities;

namespace Register.WEB.Services
{
    public class PeopleService : IPeopleService
    {
        public HttpClient HttpClient { get; set; }

        public PeopleService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<People>> GetAll()
        {
            var People = await HttpClient.GetFromJsonAsync<IEnumerable<People>>("api/People");

            return People;
        }

        public async Task<People> GetPersonByName(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<People> NewPerson(People Person)
        {
            throw new NotImplementedException();
        }

        public async Task<People> UpdatePerson(People Person)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePerson(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
