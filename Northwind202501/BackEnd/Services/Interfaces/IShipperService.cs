using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IShipperService
    {

        void AddShipper(ShipperDTO Shipper);
        void UpdateShipper(ShipperDTO Shipper);
        void DeleteShipper(int id);
        List<ShipperDTO> GetShippers();
        ShipperDTO GetShipperById(int id);
    }
}
