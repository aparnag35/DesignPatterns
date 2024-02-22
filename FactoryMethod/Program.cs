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



// Client code
class Program
{
    static void Main(string[] args)
    {
        // Client creates object based on requirement
        IProduct productA = new ConcreteProductA();
        productA.Operation();

        IProduct productB = new ConcreteProductB();
        productB.Operation();
        Console.ReadLine();
    }
}
