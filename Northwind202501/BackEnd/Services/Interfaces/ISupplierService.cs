using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface ISupplierService
    {
        SupplierDTO Get();
        List<SupplierDTO> GetAll();

        SupplierDTO Add(SupplierDTO supplierDTO);
        SupplierDTO Update(SupplierDTO supplierDTO);
        SupplierDTO Delete(int id);



    }
}
