using ImplementCors.Base;
using Microsoft.AspNetCore.Http;
using NETCore.Models;
using NETCore.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ImplementCors.Repository.Data
{
    public class PersonRepository : GeneralRepository<Person, string>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;

        public PersonRepository(Address address, string request = "Persons/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", _contextAccessor.HttpContext.Session.GetString("JWToken"));
        }
        public async Task<List<GetPersonVM>> GetAllPersons()
        {
            List<GetPersonVM> entities = new List<GetPersonVM>();

            using (var response = await httpClient.GetAsync(request + "getpersonvm"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<GetPersonVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<GetPersonVM>> GetPersonsID(string id)
        {
            List<GetPersonVM> entities = new List<GetPersonVM>();

            using (var response = await httpClient.GetAsync(request + "GetNIK/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<GetPersonVM>>(apiResponse);
            }
            return entities;
        }
        public string PostPerson(GetPersonVM getPersonVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(getPersonVM), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + request + "InsertPerson", content).Result.Content.ReadAsStringAsync().Result;
            return result;
        }
    }
}
