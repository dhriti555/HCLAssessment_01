using System.Collections.Generic;
using System.Linq;
using SupplierManagement.Models;
using SupplierManagement.Interfaces;

namespace SupplierManagement.Operations
{
    public class SupplierOperation : ISupplier
    {
        private List<Supplier> suppliers = new List<Supplier>();

        public int AddSupplier(Supplier supplier)
        {
            suppliers.Add(supplier);
            return 1;
        }

        public int UpdateSupplier(Supplier supplier)
        {
            var existing = suppliers.FirstOrDefault(s => s.Id == supplier.Id);

            if (existing == null)
                return 0;

            existing.Name = supplier.Name;
            existing.Price = supplier.Price;
            existing.Value = supplier.Value;
            existing.Email = supplier.Email;
            existing.Phone = supplier.Phone;

            return 1;
        }

        public int DeleteSupplier(int supplierId)
        {
            var existing = suppliers.FirstOrDefault(s => s.Id == supplierId);

            if (existing == null)
                return 0;

            suppliers.Remove(existing);
            return 1;
        }

        public List<Supplier> GetAllSuppliers()
        {
            return suppliers;
        }

        public Supplier? GetSupplierById(int supplierId)
        {
            return suppliers.FirstOrDefault(s => s.Id == supplierId);
        }

        public IEnumerable<object> GetSupplierIdAndName()
        {
            return suppliers.Select(s => new
            {
                s.Id,
                s.Name
            }).ToList<object>();
        }
    }
}