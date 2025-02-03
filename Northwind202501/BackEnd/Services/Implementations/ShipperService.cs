using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System.Collections.Generic;

namespace BackEnd.Services.Implementations
{
    public class ShipperService : IShipperService
    {

        IUnidadDeTrabajo _unidadDeTrabajo;

        public ShipperService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        Shipper Convertir(ShipperDTO shipper)
        {
            return new Shipper
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone
            };
        }
        ShipperDTO Convertir(Shipper shipper)
        {
            return new ShipperDTO
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone
            };
        }

        public void AddShipper(ShipperDTO Shipper)
        {

            var entity = Convertir(Shipper);

            _unidadDeTrabajo.ShipperDAL.Add(entity);
            _unidadDeTrabajo.Complete();
        }

        public void DeleteShipper(int id)
        {
            Shipper entity = new Shipper() { ShipperId = id };
            _unidadDeTrabajo.ShipperDAL.Remove(entity);
            _unidadDeTrabajo.Complete();
        }

        public List<ShipperDTO> GetShippers()
        {
            var datos = _unidadDeTrabajo.ShipperDAL.GetAll().ToList() ?? new();
            List<ShipperDTO> entities = new();
            foreach (var entity in datos)
            {
                entities.Add(Convertir(entity));
            }
            return entities;
        }

        public void UpdateShipper(ShipperDTO Shipper)
        {
            var entity = Convertir(Shipper);

            _unidadDeTrabajo.ShipperDAL.Update(entity);
            _unidadDeTrabajo.Complete();
        }

        public ShipperDTO GetShipperById(int id)
        {
            var result = _unidadDeTrabajo.ShipperDAL.Get(id);
            return Convertir(result);

        }
    }
}
