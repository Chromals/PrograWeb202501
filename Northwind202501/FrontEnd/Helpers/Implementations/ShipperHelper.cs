using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class ShipperHelper : IShipperHelper
    {
        IServiceRepository _ServiceRepository;

        ShipperViewModel Convertir(ShipperAPI shipper)
        {
            ShipperViewModel shipperViewModel = new ShipperViewModel
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone
            };
            return shipperViewModel;
        }


        public ShipperHelper(IServiceRepository serviceRepository)
        {
            _ServiceRepository = serviceRepository;
        }

        public ShipperViewModel Add(ShipperViewModel shipper)
        {
            HttpResponseMessage response = _ServiceRepository.PostResponse("api/Shipper", shipper);
            if (response.IsSuccessStatusCode)
            {

                var content = response.Content.ReadAsStringAsync().Result;
            }
            return shipper;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ShipperViewModel> GetCategories()
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Shipper");
            List<ShipperAPI> categories = new List<ShipperAPI>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                categories = JsonConvert.DeserializeObject<List<ShipperAPI>>(content);
            }
            List<ShipperViewModel> lista = new List<ShipperViewModel>();
            foreach (var shipper in categories)
            {
                lista.Add(Convertir(shipper));
            }   
            return lista;
        }

        public ShipperViewModel GetShipper(int? id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Shipper/" + id.ToString());
            ShipperAPI shipper = new ShipperAPI();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                shipper = JsonConvert.DeserializeObject<ShipperAPI>(content);
            }

            ShipperViewModel resultado = Convertir(shipper);


            return resultado;
        }

        public ShipperViewModel Update(ShipperViewModel shipper)
        {
            throw new NotImplementedException();
        }
    }
}
