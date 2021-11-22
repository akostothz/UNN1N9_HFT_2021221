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
    public class AlbumController : ControllerBase
    {
        IAlbumLogic albumLogic;

        public AlbumController(IAlbumLogic alLog)
        {
            this.albumLogic = alLog;
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
        }

        // PUT /album
        [HttpPut]
        public void Put([FromBody] Album value)
        {
            albumLogic.Update(value);
        }

        // DELETE /album/4
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            albumLogic.Delete(id);
        }
    }
}
