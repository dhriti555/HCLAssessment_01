using System.Collections.Generic;
using SupplierManagement.Models;

namespace SupplierManagement.Interfaces
{
    public interface ISupplier
    {
        int AddSupplier(Supplier supplier);
        int UpdateSupplier(Supplier supplier);
        int DeleteSupplier(int supplierId);
        List<Supplier> GetAllSuppliers();
        Supplier? GetSupplierById(int supplierId);
        IEnumerable<object> GetSupplierIdAndName();
    }
}