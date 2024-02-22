using System;

// Product interface
public interface IProduct
{
    void Operation();
}

// Concrete products
public class ConcreteProductA : IProduct
{
    public void Operation()
    {
        Console.WriteLine("Concrete Product A operation");
    }
}

public class ConcreteProductB : IProduct
{
    public void Operation()
    {
        Console.WriteLine("Concrete Product B operation");
    }
}

// Simple Factory
public class SimpleFactory
{
    public IProduct CreateProduct(string productType)
    {
        switch (productType)
        {
            case "A":
                return new ConcreteProductA();
            case "B":
                return new ConcreteProductB();
            default:
                throw new ArgumentException("Invalid product type");
        }
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        SimpleFactory factory = new SimpleFactory();

        // Client requests a product from the factory
        IProduct productA = factory.CreateProduct("A");
        productA.Operation();

        IProduct productB = factory.CreateProduct("B");
        productB.Operation();
        Console.ReadLine();
    }
}
