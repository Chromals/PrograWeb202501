using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        IShipperService _shipperService;

        public ShipperController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        // GET: api/<ShipperController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ShipperController>
        [HttpPost]
        public void Post([FromBody] ShipperDTO shipper)
        {
            _shipperService.AddShipper(shipper); 

        }

        // PUT api/<ShipperController>/5
        [HttpPut]
        public void Put( [FromBody] Shipper shipper)
        {
            _shipperService.UpdateShipper(shipper);

        }

        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
