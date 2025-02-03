using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IShipperService
    {

        void AddShipper(ShipperDTO Shipper);
        void UpdateShipper(Shipper Shipper);
        void DeleteShipper(int id);
        List<Shipper> GetShippers();
    }
}
