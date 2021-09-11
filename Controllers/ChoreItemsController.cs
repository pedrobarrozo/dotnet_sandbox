using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.Models;
using TestApi.Repositories;
using System.Linq;
using System.Text.Json;

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

        // GET: api/Chores
        [HttpGet]
        [Produces(typeof(ChoreItem))]
        public IActionResult Get()
        {
            var chore = _choreRepository.GetAll();
            if (chore.Count() == 0)
                return NoContent();
            return Ok(chore);
        }

        // GET: api/Chores/<int: id>
        [HttpGet("{id}")]
        [Produces(typeof(ChoreItem))]
        public IActionResult Get(int id)
        {
            var chore = _choreRepository.Get(id);
            if (chore.Count() == 0)
                return NoContent();
            return Ok(chore);
        }

        // POST: api/Chores
        [HttpPost]
        public ChoreItem Post(ChoreItem chore)
        {
            var resp = _choreRepository.Create(chore);
            return resp;
        }

        // POST: api/Chores/<int: id>
        [HttpPut("{id}")]
        public IEnumerable<ChoreItem> Put(int id, ChoreItem chore)
        {
            var resp = _choreRepository.Update(id, chore);
            return resp;
        }
    }
}
