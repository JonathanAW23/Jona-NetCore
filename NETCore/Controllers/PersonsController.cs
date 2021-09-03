using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore.Base;
using NETCore.Models;
using NETCore.Repository.Data;
using NETCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : BaseController<Person, PersonRepository, string>
    {
        private readonly PersonRepository personRepository;
        public PersonsController(PersonRepository repository) : base(repository)
        {
            this.personRepository = repository;
        }
                                                   
        [HttpPost("InsertPerson")]
        public ActionResult InsertPerson(GetPersonVM getPersonVM)
        {
            try
            {
                if (string.IsNullOrEmpty(getPersonVM.NIK))
                {
                    return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = "NIK tidak boleh kosong" });
                }
                else if (string.IsNullOrEmpty(getPersonVM.FullName))
                {
                    return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = "Nama tidak boleh kosong" });
                }
                else if (personRepository.CheckPersonVMEmail(getPersonVM.Email) == false)
                {
                    return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = "Email sudah ada" });                    
                }
                else if (personRepository.CheckPersonVMPhone(getPersonVM.Phone) == false)
                {
                    return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = "Phone number sudah ada" });
                }
                else 
                {
                    personRepository.InsertPerson(getPersonVM);
                    return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = "Sukses insert data" });
                }    
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Status = (int)HttpStatusCode.InternalServerError, Message = e.Message });
            }

        }

        [HttpGet("GetPersonVM")]

        public ActionResult GetPersonVM()
        {
            var person = personRepository.GetPersonVMs();
            if (person == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound, new { status = (int)HttpStatusCode.NotFound, data = "No result" });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = person });
            }
        }

        [HttpGet("GetNIK/{NIK}")]

        public ActionResult GetNIK(string NIK)
        {
            var person = personRepository.GetPersonVMsNIK(NIK);
            if (person == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound, new { status = (int)HttpStatusCode.NotFound, data = "No result" });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = person });
            }
        }
    }
}
