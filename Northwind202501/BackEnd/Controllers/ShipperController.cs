using BackEnd.DTO;
using BackEnd.Services.Implementations;
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
        public IEnumerable<ShipperDTO> Get()
        {
            return _shipperService.GetShippers();
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public ShipperDTO Get(int id)
        {
            return _shipperService.GetShipperById(id);
        }

        // POST api/<ShipperController>
        [HttpPost]
        public void Post([FromBody] ShipperDTO shipper)
        {
            _shipperService.AddShipper(shipper); 

        }

        // PUT api/<ShipperController>/5
        [HttpPut]
        public void Put( [FromBody] ShipperDTO shipper)
        {
            _shipperService.UpdateShipper(shipper);

        }

        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _shipperService.DeleteShipper(id);
        }
    }
}
