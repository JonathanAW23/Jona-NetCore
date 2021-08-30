using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NETCore.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repository;

        public BaseController(Repository repository) 
        {
            this.repository = repository;
        }

        [HttpPost]
        public ActionResult Insert(Entity entity)
        {
            try
            {
                repository.Insert(entity);
                return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = "Sukses Insert Data" });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Status = (int)HttpStatusCode.InternalServerError, Message = e.Message });
            }

        }

        [HttpGet]

        public ActionResult Get()
        {
            var temp = repository.Get();
            if (temp == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound, new { status = (int)HttpStatusCode.NotFound, data = "No result" });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = repository.Get() });
            }
        }

        [HttpGet("{key}")]

        public ActionResult GetKey(Key key)
        {
            var temp = repository.Get(key);
            if (temp == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound, new { status = (int)HttpStatusCode.NotFound, data = "No result" });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = repository.Get(key) });
            }
        }

        [HttpPut]

        public ActionResult update(Entity entity)
        {
            try
            {
                repository.Update(entity);
                return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = "Sukses Update Data" });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Status = (int)HttpStatusCode.InternalServerError, Message = e.Message });
            }

        }

        [HttpDelete("{key}")]

        public ActionResult Delete(Key key)
        {
            try
            {
                repository.Delete(key);
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

