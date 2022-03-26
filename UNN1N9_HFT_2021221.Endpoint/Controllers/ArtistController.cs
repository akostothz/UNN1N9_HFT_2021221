using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UNN1N9_HFT_2021221.Endpoint.Services;
using UNN1N9_HFT_2021221.Logic;
using UNN1N9_HFT_2021221.Models;

namespace UNN1N9_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        IArtistLogic artistLogic;
        IHubContext<SignalRHub> hub;

        public ArtistController(IArtistLogic arLog, IHubContext<SignalRHub> hub)
        {
            this.artistLogic = arLog;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("ArtistCreated", value);
        }

        // PUT /artist
        [HttpPut]
        public void Put([FromBody] Artist value)
        {
            artistLogic.Update(value);
            this.hub.Clients.All.SendAsync("ArtistUpdated", value);
        }

        // DELETE /artist/4
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var artistToDelete = this.artistLogic.Read(id);
            artistLogic.Delete(id);
            this.hub.Clients.All.SendAsync("SongDeleted", artistToDelete);
        }
    }
}
