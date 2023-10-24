// Program 2: Encapsulation with Online Ordering
Description:
In this program, I will design classes for Product, Customer, Address, and Order to help manage online product orders. The Order class will contain a list of products and a customer, allowing it to calculate the total cost, generate packing and shipping labels. 
The Product class will store product details, and the Customer class will hold customer information along with an address. 
The Address class will include the customer's address details.
All member variables will be made private, and getters, setters, and constructors will be provided as needed. I will create at least two orders with products and display packing labels, shipping labels, and total order prices.

// Program is the main entry point of the application. It interacts with the user, collects input, and coordinates the creation of other objects.
Product, Address, Customer, and Order are the primary classes used in the program.
Each class has its properties (attributes) and methods as described in the code examples.
Order has a list of Product objects, representing the products in the order. It also has a reference to a Customer object, representing the customer making the order.
The methods in each class correspond to their responsibilities. For example, GeneratePackingLabel() and GenerateShippingLabel() are used to generate labels for the order.



using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Online Ordering System");

        // Input from the user
        Console.Write("Customer Name: ");
        string customerName = Console.ReadLine();

        Console.Write("Street Address: ");
        string streetAddress = Console.ReadLine();

        Console.Write("City: ");
        string city = Console.ReadLine();

        Console.Write("State/Province: ");
        string state = Console.ReadLine();

        Console.Write("Country: ");
        string country = Console.ReadLine();

        Address customerAddress = new Address(streetAddress, city, state, country);
        Customer customer = new Customer(customerName, customerAddress);
        Order order = new Order(customer);

        while (true)
        {
            Console.Write("Product Name (or 'done' to finish): ");
            string productName = Console.ReadLine();

            if (productName.ToLower() == "done")
                break;

            Console.Write("Product ID: ");
            int productID;
            if (!int.TryParse(Console.ReadLine(), out productID))
            {
                Console.WriteLine("Invalid product ID. Please enter a number.");
                continue;
            }

            Console.Write("Price: $");
            decimal price;
            if (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid price. Please enter a valid number.");
                continue;
            }

            Console.Write("Quantity: ");
            int quantity;
            if (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Invalid quantity. Please enter a number.");
                continue;
            }

            Product product = new Product(productName, productID, price, quantity);
            order.AddProduct(product);
        }

        // Calculate and display the total cost
        decimal totalCost = order.CalculateTotalCost();
        Console.WriteLine($"Total Order Cost: ${totalCost}");

        // Generate and display packing label
        string packingLabel = order.GeneratePackingLabel();
        Console.WriteLine(packingLabel);

        // Generate and display shipping label
        string shippingLabel = order.GenerateShippingLabel();
        Console.WriteLine(shippingLabel);
    }
}

class Product
{
    public string Name { get; private set; }
    public int ProductID { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public Product(string name, int productID, decimal price, int quantity)
    {
        Name = name;
        ProductID = productID;
        Price = price;
        Quantity = quantity;
    }

    public decimal CalculateTotalPrice()
    {
        return Price * Quantity;
    }
}

class Address
{
    public string StreetAddress { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }

    public Address(string streetAddress, string city, string state, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        State = state;
        Country = country;
    }

    public bool IsInUSA()
    {
        return string.Equals(Country, "Nigeria", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFormattedAddress()
    {
        return $"{StreetAddress}, {City}, {State}, {Country}";
    }
}

class Customer
{
    public string Name { get; private set; }
    public Address CustomerAddress { get; private set; }

    public Customer(string name, Address address)
    {
        Name = name;
        CustomerAddress = address;
    }

    public bool IsCustomerInUSA()
    {
        return CustomerAddress.IsInUSA();
    }
}

class Order
{
    private List<Product> productList = new List<Product>();
    public Customer Customer { get; private set; }

    public Order(Customer customer)
    {
        Customer = customer;
    }

    public void AddProduct(Product product)
    {
        productList.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;
        foreach (var product in productList)
        {
            totalCost += product.CalculateTotalPrice();
        }

        // Shipping cost based on the customer's location
        decimal shippingCost = Customer.IsCustomerInUSA() ? 5m : 35m;

        return totalCost + shippingCost;
    }

    public string GeneratePackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in productList)
        {
            packingLabel += $"{product.Name} (Product ID: {product.ProductID})\n";
        }
        return packingLabel;
    }

    public string GenerateShippingLabel()
    {
        string shippingLabel = "Shipping Label:\n";
        shippingLabel += $"Customer Name: {Customer.Name}\n";
        shippingLabel += Customer.CustomerAddress.GetFormattedAddress();
        return shippingLabel;
    }
}

class Program
{
    static void Main()
    {
        // Create a sample address
        Address customerAddress = new Address("163 Iremo Road", "ile-ife", "LA", "Nigeria");

        // Create a customer
        Customer customer = new Customer("Omikunle Timileyin", customerAddress);

        // Create an order
        Order order = new Order(customer);

        // Adding products to the order
        Product product1 = new Product("Product A", 1, 10.0m, 2);
        Product product2 = new Product("Product B", 2, 15.0m, 1);
        order.AddProduct(product1);
        order.AddProduct(product2);

        // Calculate and display the total cost
        decimal totalCost = order.CalculateTotalCost();
        Console.WriteLine($"Total Order Cost: ${totalCost}");

        // Generate and display packing label
        string packingLabel = order.GeneratePackingLabel();
        Console.WriteLine(packingLabel);

        // Generate and display shipping label 
        string shippingLabel = order.GenerateShippingLabel();
        Console.WriteLine(shippingLabel);
    }
}


