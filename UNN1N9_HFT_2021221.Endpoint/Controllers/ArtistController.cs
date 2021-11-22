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
    public class ArtistController : ControllerBase
    {
        IArtistLogic artistLogic;

        public ArtistController(IArtistLogic arLog)
        {
            this.artistLogic = arLog;
        }

        // GET: /artist
        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            return artistLogic.ReadAll();
        }

        // GET /artist/4
        [HttpGet("{id}")]
        public Artist Get(int id)
        {
            return artistLogic.Read(id);
        }

        // POST /artist
        [HttpPost]
        public void Post([FromBody] Artist value)
        {
            artistLogic.Create(value);
        }

        // PUT /artist
        [HttpPut]
        public void Put([FromBody] Artist value)
        {
            artistLogic.Update(value);
        }

        // DELETE /artist/4
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            artistLogic.Delete(id);
        }
    }
}
