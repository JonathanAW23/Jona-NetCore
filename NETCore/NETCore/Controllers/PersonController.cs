using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore.Base;
using NETCore.Models;
using NETCore.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController<Person, PersonRepository, string>
    {
        public PersonController(PersonRepository repository) : base(repository)
        {
        }
    }
}
