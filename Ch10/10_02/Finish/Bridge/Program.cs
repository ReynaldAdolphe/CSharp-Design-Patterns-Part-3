using System;

/// <summary>
/// This code demonstrates the bridge pattern by sending messages using 
/// two independent systems. One by text & the other, webservice.
/// </summary>
namespace Bridge.Demonstration
{
    /// <summary>
    /// Bridge Design Pattern Demo
    /// </summary>
    class Client
    {
        static void Main()
        {
            // TODO
        }
    }

    /// <summary>
    /// The 'Abstraction' class
    /// </summary>
    public abstract class Message
    {
        public IMessageSender MessageSender { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public abstract void Send();
    }

    /// <summary>
    /// The 'RefinedAbstraction' class
    /// </summary>
    public class SystemMessage : Message
    {
        public override void Send()
        {
            MessageSender.SendMessage(Subject, Body);
        }
    }

    /// <summary>
    /// The 'Bridge/Implementor' interface
    /// </summary>
    public interface IMessageSender
    {
        void SendMessage(string subject, string body);
    }

    /// <summary>
    /// The 'ConcreteImplementor' class
    /// </summary>
    public class TextSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            string messageType = "Text";
            Console.WriteLine($"{messageType}");
            Console.WriteLine("--------------");
            Console.WriteLine($"Subject:  {subject} from {messageType}\nBody:  {body}\n");
        }
    }

    /// <summary>
    /// The 'ConcreteImplementor' class
    /// </summary>
    public class WebServiceSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            string messageType = "Web Service";
            Console.WriteLine($"{messageType}");
            Console.WriteLine("--------------");
            Console.WriteLine($"Subject:  {subject} from {messageType}\nBody:  {body}\n");
        }
    }
}