using System;
using System.Collections.Generic;

// Address class
public class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsUSA()
    {
        return country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return street + "\n" + city + ", " + state + "\n" + country;
    }
}

// Customer class
public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string GetName()
    {
        return name;
    }

    public bool LivesInUSA()
    {
        return address.IsUSA();
    }

    public string GetAddress()
    {
        return address.GetFullAddress();
    }
}

// Product class
public class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public string GetPackingInfo()
    {
        return name + " (ID: " + productId + ")";
    }
}

// Order class
public class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double total = 0;

        foreach (Product p in products)
        {
            total += p.GetTotalCost();
        }

        // Shipping cost
        if (customer.LivesInUSA())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        string result = "Packing Label:\n";

        foreach (Product p in products)
        {
            result += p.GetPackingInfo() + "\n";
        }

        return result;
    }

    public string GetShippingLabel()
    {
        return "Shipping Label:\n" + customer.GetName() + "\n" + customer.GetAddress();
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Online Ordering System\n");

        // Order 1 (USA)
        Address addr1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer cust1 = new Customer("John Smith", addr1);

        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "A101", 800, 1));
        order1.AddProduct(new Product("Mouse", "B202", 20, 2));

        // Order 2 (International)
        Address addr2 = new Address("456 Street", "Toronto", "ON", "Canada");
        Customer cust2 = new Customer("Maria Lopez", addr2);

        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Phone", "C303", 600, 1));
        order2.AddProduct(new Product("Headphones", "D404", 50, 2));

        // Display Order 1
        Console.WriteLine("ORDER 1");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order1.CalculateTotalCost());

        Console.WriteLine("\n----------------------\n");

        // Display Order 2
        Console.WriteLine("ORDER 2");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order2.CalculateTotalCost());
    }
}