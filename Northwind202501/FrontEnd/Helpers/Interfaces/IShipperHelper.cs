using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IShipperHelper
    {

        List<ShipperViewModel> GetCategories();

        ShipperViewModel GetShipper(int? id);
        ShipperViewModel Add(ShipperViewModel shipper);
        ShipperViewModel Update(ShipperViewModel shipper);
        void Delete(int id);
    }
}
