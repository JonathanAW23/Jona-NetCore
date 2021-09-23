using ImplementCors.Base;
using ImplementCors.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NETCore.Models;
using NETCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementCors.Controllers
{
    public class PersonsController : BaseController<Person, PersonRepository, string>
    {
        private readonly PersonRepository repository;
        public PersonsController(PersonRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<JsonResult> GetAllPersons()
        {
            var result = await repository.GetAllPersons();
            return Json(result);
        }

        [HttpGet]
        public async Task<JsonResult> GetPersonsID(string id)
        {
            var result = await repository.GetPersonsID(id);
            return Json(result);
        }

        [HttpPost]
        public JsonResult PostPerson([FromBody]GetPersonVM getPersonVM)
        {
            var result = repository.PostPerson(getPersonVM);
            return Json(result);
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
