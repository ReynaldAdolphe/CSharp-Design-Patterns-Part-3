using System;

/// <summary>
/// This code demonstrates the Proxy pattern for a Math object 
/// represented by a CalculateProxy object.
/// </summary>
namespace Proxy.Demonstration
{
    /// <summary>
    /// Proxy Design Pattern.
    /// </summary>
    class Client
    {
        static void Main()
        {
            // Create math proxy
            CalculateProxy proxy = new CalculateProxy();

            // Do some math
            Console.WriteLine("Calculations");
            Console.WriteLine("-------------");
            Console.WriteLine("\n10 + 5 = " + proxy.Add(10, 5));
            Console.WriteLine("\n10 - 5 = " + proxy.Subtract(10, 5));
            Console.WriteLine("\n10 * 5 = " + proxy.Multiply(10, 5));
            Console.WriteLine("\n10 / 5 = " + proxy.Divide(10, 5));

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Subject interface
    /// </summary>
    public interface IMath
    {
        double Add(double x, double y);
        double Subtract(double x, double y);
        double Multiply(double x, double y);
        double Divide(double x, double y);
    }

    /// <summary>
    /// The 'RealSubject' class
    /// </summary>
    class Math : IMath
    {
        public double Add(double x, double y) { return x + y; }
        public double Subtract(double x, double y) { return x - y; }
        public double Multiply(double x, double y) { return x * y; }
        public double Divide(double x, double y) { return x / y; }
    }

    /// <summary>
    /// The 'Proxy Object' class
    /// </summary>
    class CalculateProxy : IMath
    {
        private Math _math = new Math();

        public double Add(double x, double y)
        {
            return _math.Add(x, y);
        }
        public double Subtract(double x, double y)
        {
            return _math.Subtract(x, y);
        }
        public double Multiply(double x, double y)
        {
            return _math.Multiply(x, y);
        }
        public double Divide(double x, double y)
        {
            return _math.Divide(x, y);
        }
    }
}
