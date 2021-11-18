using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UNN1N9_HFT_2021221.Logic;
using UNN1N9_HFT_2021221.Models;

namespace UNN1N9_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        ISongLogic songLogic;

        public SongController(ISongLogic sLog)
        {
            this.songLogic = sLog;
        }
        
        // GET: /song
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return songLogic.ReadAll();
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SongController>
        [HttpPost]
        public void Post([FromBody] string value) //create
        {
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) //update
        {
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
