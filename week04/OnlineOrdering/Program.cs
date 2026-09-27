using System;

class Program
{
    static void Main(string[] args)
    {
        // ----- ORDER 1 (Customer in EE. UU.) -----
        Address address1 = new Address("123 Main St", "springfield", "IL", "USA");
        Customer customer1 = new Customer("John Cruz", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "P1001", 899.99, 1));
        order1.AddProduct(new Product("Mousse Inalambrico", "P1002", 25.50, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():F2}\n");
        Console.WriteLine(new string('=', 40) + "\n");

        // ----- ORDER 2 (International Customer) -----
        Address address2 = new Address("456 Major St", "Madrid", "Madrid", "Spain");
        Customer customer2 = new Customer("Maria Garcia", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Mechanical Keyboard", "P2001", 75.00, 1));
        order2.AddProduct(new Product("Monitor 24 Inches", "P2002", 150.00, 2));
        order2.AddProduct(new Product("HDMI cable", "P2003", 10.00, 3));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():F2}\n");

    }
}