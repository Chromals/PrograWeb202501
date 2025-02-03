using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class ShipperService : IShipperService
    {

        IUnidadDeTrabajo _unidadDeTrabajo;

        public ShipperService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo= unidadDeTrabajo;
        }

        public void AddShipper(ShipperDTO Shipper)
        {

            var ShipperEntity = new Shipper()
            {
                CompanyName = Shipper.CompanyName,
                Phone = Shipper.Phone
                
            };  

            _unidadDeTrabajo.ShipperDAL.Add(ShipperEntity);
            _unidadDeTrabajo.Complete();
        }

        public void DeleteShipper(int id)
        {
            Shipper elim = new Shipper() { ShipperId = id };
            _unidadDeTrabajo.ShipperDAL.Remove(elim);
            _unidadDeTrabajo.Complete();
        }

        public List<Shipper> GetShippers()
        {
            var datos = _unidadDeTrabajo.ShipperDAL.GetAll().ToList() ?? new() ;
            return datos;
        }

        public void UpdateShipper(Shipper Shipper)
        {
           _unidadDeTrabajo.ShipperDAL.Update(Shipper);
            _unidadDeTrabajo.Complete();
        }
    }
}
