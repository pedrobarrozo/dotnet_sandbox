using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.Models;
using TestApi.Repositories;
using System.Linq;

namespace TestApi.Controller
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ChoreController : ControllerBase
    {
        private readonly IChoreRepository _choreRepository;
        public ChoreController(IChoreRepository choreRepository)
        {
            _choreRepository = choreRepository;
        }
        [HttpGet]
        [Produces(typeof(ChoreItem))]
        public IActionResult Get()
        {
            var chore = _choreRepository.GetAll();
            if (chore.Count() == 0)
                return NoContent();
            return Ok(chore);
        }
    }
}
