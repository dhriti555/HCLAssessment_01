using SupplierManagement.Models;
using SupplierManagement.Operations;

SupplierOperation operation = new SupplierOperation();

while (true)
{
    Console.WriteLine("\n--- Supplier Management ---");
    Console.WriteLine("1. Add Supplier");
    Console.WriteLine("2. View All Suppliers");
    Console.WriteLine("3. Update Supplier");
    Console.WriteLine("4. Delete Supplier");
    Console.WriteLine("5. Search Supplier by ID");
    Console.WriteLine("6. View Supplier ID and Name");
    Console.WriteLine("0. Exit");
    Console.Write("Enter your choice: ");

    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.WriteLine("Invalid input.");
        continue;
    }

    if (choice == 0)
        break;

    switch (choice)
    {
        case 1:
            Supplier newSupplier = new Supplier();

            Console.Write("Enter ID: ");
            newSupplier.Id = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Name: ");
            newSupplier.Name = Console.ReadLine()!;

            Console.Write("Enter Price: ");
            newSupplier.Price = decimal.Parse(Console.ReadLine()!);

            Console.Write("Enter Value: ");
            newSupplier.Value = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Email: ");
            newSupplier.Email = Console.ReadLine()!;

            Console.Write("Enter Phone: ");
            newSupplier.Phone = Console.ReadLine()!;

            Console.WriteLine(
                operation.AddSupplier(newSupplier) == 1
                    ? "Supplier added successfully."
                    : "Unable to add supplier.");
            break;

        case 2:
            foreach (Supplier supplier in operation.GetAllSuppliers())
            {
                Console.WriteLine(
                    $"{supplier.Id} | {supplier.Name} | {supplier.Price} | {supplier.Value} | {supplier.Email} | {supplier.Phone}");
            }
            break;

        case 3:
            Supplier updateSupplier = new Supplier();

            Console.Write("Enter ID to update: ");
            updateSupplier.Id = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Name: ");
            updateSupplier.Name = Console.ReadLine()!;

            Console.Write("Enter Price: ");
            updateSupplier.Price = decimal.Parse(Console.ReadLine()!);

            Console.Write("Enter Value: ");
            updateSupplier.Value = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Email: ");
            updateSupplier.Email = Console.ReadLine()!;

            Console.Write("Enter Phone: ");
            updateSupplier.Phone = Console.ReadLine()!;

            Console.WriteLine(
                operation.UpdateSupplier(updateSupplier) == 1
                    ? "Supplier updated successfully."
                    : "Supplier not found.");
            break;

        case 4:
            Console.Write("Enter ID to delete: ");
            int deleteId = int.Parse(Console.ReadLine()!);

            Console.WriteLine(
                operation.DeleteSupplier(deleteId) == 1
                    ? "Supplier deleted successfully."
                    : "Supplier not found.");
            break;

        case 5:
            Console.Write("Enter Supplier ID: ");
            int searchId = int.Parse(Console.ReadLine()!);

            Supplier? found = operation.GetSupplierById(searchId);

            Console.WriteLine(found == null
                ? "Supplier not found."
                : $"{found.Id} | {found.Name} | {found.Price} | {found.Value} | {found.Email} | {found.Phone}");
            break;

        case 6:
            foreach (var item in operation.GetSupplierIdAndName())
            {
                Console.WriteLine(item);
            }
            break;

        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}