using System;
using System.Collections.Generic;
using System.Text;

class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public string Name { get { return _name; } }
    public string ProductId { get { return _productId; } }
    public double Price { get { return _price; } }
    public int Quantity { get { return _quantity; } }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }
}

class Address
{
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.Trim().ToUpper() == "USA" || _country.Trim().ToUpper() == "UNITED STATES" || _country.Trim().ToUpper() == "UNITED STATES OF AMERICA";
    }

    public override string ToString()
    {
        return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}

class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string Name { get { return _name; } }
    public Address Address { get { return _address; } }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }
}

class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double totalProductCost = 0;
        foreach (Product p in _products)
        {
            totalProductCost += p.GetTotalCost();
        }

        double shippingCost = _customer.IsInUSA() ? 5 : 35;

        return totalProductCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Product p in _products)
        {
            sb.AppendLine($"Product: {p.Name} (ID: {p.ProductId})");
        }
        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        return $"{_customer.Name}\n{_customer.Address}";
    }
}

class Program
{
    static void Main()
    {
        // Crear dirección de cliente 1 (en USA)
        Address address1 = new Address("123 Maple St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        // Crear pedido 1
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "A123", 1200.00, 1));
        order1.AddProduct(new Product("Mouse", "B456", 25.50, 2));
        order1.AddProduct(new Product("Keyboard", "C789", 45.00, 1));

        // Crear dirección de cliente 2 (fuera de USA)
        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);

        // Crear pedido 2
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Smartphone", "D234", 800.00, 1));
        order2.AddProduct(new Product("Headphones", "E567", 150.00, 1));

        // Mostrar info pedido 1
        Console.WriteLine("Pedido 1:");
        Console.WriteLine("Etiqueta de embalaje:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Etiqueta de envío:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Costo total: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine();

        // Mostrar info pedido 2
        Console.WriteLine("Pedido 2:");
        Console.WriteLine("Etiqueta de embalaje:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Etiqueta de envío:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Costo total: ${order2.CalculateTotalCost():F2}");
    }
}
