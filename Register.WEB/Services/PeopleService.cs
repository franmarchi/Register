using Register.API.Entities;
using Register.API.Repositories;
using System.Net.Http;
using System.Text.Json;

namespace Register.WEB.Services
{
    public class PeopleService : IPeopleRepository
    {
        public HttpClient HttpClient { get; set; }
        
        public  readonly JsonSerializerOptions _options;

        public PeopleService(HttpClient httpClient)
        {
            HttpClient = httpClient;
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }
        
        public async Task<List<People>> GetAll()
        {
            var people = await HttpClient.GetAsync("api/People");

            var response = await people.Content.ReadFromJsonAsync<List<People>>();

            return response!;
        }

        public async Task<People> GetPersonById(int Id)
        {
            var person = await HttpClient.GetAsync($"api/People/Person/{Id}");

            var response = await person.Content.ReadFromJsonAsync<People>();

            return response!;
        }

        public async Task<People> GetPersonByName(string Name)
        {
            var person = await HttpClient.GetAsync($"api/People/{Name}");
            
            var response = await person.Content.ReadFromJsonAsync<People>();
            
            return response!;
        }

        public async Task<People> NewPerson(People Person)
        {
            var person = await HttpClient.PostAsJsonAsync("api/People/NewPerson", Person);
            
            var response = await person.Content.ReadFromJsonAsync<People>();
            
            return response!;
        }

        public async Task<People> UpdatePerson(People Person)
        {
            var person = await HttpClient.PutAsJsonAsync("api/People/UpdatePerson", Person);
            
            var response = await person.Content.ReadFromJsonAsync<People>();
            
            return response!;
        }

        public async Task<People> DeletePerson(int Id)
        {
            var person = await HttpClient.DeleteAsync($"api/People/{Id}");

            var response = await person.Content.ReadFromJsonAsync<People>();

            return response!;
        }
    }
}
