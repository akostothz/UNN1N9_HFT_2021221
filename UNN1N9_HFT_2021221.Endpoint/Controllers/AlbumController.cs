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
    public class AlbumController : ControllerBase
    {
        IAlbumLogic albumLogic;
        IHubContext<SignalRHub> hub;

        public AlbumController(IAlbumLogic alLog, IHubContext<SignalRHub> hub)
        {
            this.albumLogic = alLog;
            this.hub = hub;
        }

        // GET: /album
        [HttpGet]
        public IEnumerable<Album> Get()
        {
            return albumLogic.ReadAll();
        }

        // GET /album/4
        [HttpGet("{id}")]
        public Album Get(int id)
        {
            return albumLogic.Read(id);
        }

        // POST /album
        [HttpPost]
        public void Post([FromBody] Album value)
        {
            albumLogic.Create(value);
            this.hub.Clients.All.SendAsync("AlbumCreated", value);
        }

        // PUT /album
        [HttpPut]
        public void Put([FromBody] Album value)
        {
            albumLogic.Update(value);
            this.hub.Clients.All.SendAsync("AlbumUpdated", value);
        }

        // DELETE /album/4
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var albumToDelete = this.albumLogic.Read(id);
            albumLogic.Delete(id);
            this.hub.Clients.All.SendAsync("AlbumDeleted", albumToDelete);
        }
    }
}
