using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore.Models;
using NETCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OldController : ControllerBase
    {
        private readonly OldRepository personRepository;
        
        public OldController(OldRepository personRepository)
        {
            this.personRepository = personRepository;
        }
        [HttpPost]
        public ActionResult Insert(Person person)
        {
            try
            {
                personRepository.Insert(person);
                return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = "Sukses Insert Data" });
            }
            catch (Exception e) 
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Status = (int)HttpStatusCode.InternalServerError, Message = e.Message});
            }

        }

        [HttpGet]

        public ActionResult Get()
        {
            var person = personRepository.Get();
            if (person == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound, new { status = (int)HttpStatusCode.NotFound, data = "No result" });
            }
            else 
            {
                return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = personRepository.Get() });
            }
        }

        [HttpGet("{NIK}")]

        public ActionResult GetNIK(string NIK)
        {
            var person = personRepository.Get(NIK);
            if (person == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound, new { status = (int)HttpStatusCode.NotFound, data = "No result" });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = personRepository.Get(NIK) });
            }
        }

        [HttpPut]

        public ActionResult update(Person person) 
        {
            try
            {
                personRepository.Update(person);
                return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = "Sukses Update Data"});
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Status = (int)HttpStatusCode.InternalServerError, Message = e.Message });
            }

        }

        [HttpDelete("{NIK}")]

        public ActionResult Delete(string NIK) 
        {
            try
            {
                personRepository.Delete(NIK);
                return StatusCode((int)HttpStatusCode.OK, new { status = HttpStatusCode.OK, data = "Sukses Delete Data" });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Status = (int)HttpStatusCode.InternalServerError, Message = e.Message });
            }
        }
    }

    public class ResponseStatus
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
