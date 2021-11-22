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

        // GET /song/4
        [HttpGet("{id}")]
        public Song Get(int id)
        {
            return songLogic.Read(id);
        }

        // POST /song
        [HttpPost]
        public void Post([FromBody] Song value) //create
        {
            songLogic.Create(value);
        }

        // PUT /song
        [HttpPut]
        public void Put([FromBody] Song value) //update
        {
            songLogic.Update(value);
        }

        // DELETE /song/4
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            songLogic.Delete(id);
        }
    }
}
