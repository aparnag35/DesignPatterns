//static class cannot implement interface. a static class cannot implement interface
//volatile means changes done in one thread is visible to other threads
using System.Threading;
public sealed class Singleton
{
    private static volatile Singleton instance;
    private static object syncRoot = new Object();

    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }

    }
    public int i;
    public void DoSomething()
    {
        i++;
    }
}

public class NonsingleTon
{

}

class clientclass
{
    static void Main()
    {
        NonsingleTon nonobj = new NonsingleTon();
        NonsingleTon nonobj2 = new NonsingleTon();
        if (nonobj == nonobj2)
        {
            Console.WriteLine("NonsingleTon Same");
        }
        else
        {
            Console.WriteLine("NonsingleTon Different");
        }
        Singleton singleton1 = Singleton.Instance;
        Singleton singleton2 = Singleton.Instance;

        if (singleton1 == singleton2)
        {
            Console.WriteLine("Singleton instances are the same.");
        }
        else
        {
            Console.WriteLine("Different Singleton instances.");
        }
        Console.WriteLine(singleton1.i);
       Thread newThread = new Thread(singleton1.DoSomething);
        newThread.Start();
        Thread.Sleep(1000);//to wait until object1 updates i
        Console.WriteLine(singleton2.i);//object2 also reflects changes done by object1
        Console.ReadLine();
    }
   
}