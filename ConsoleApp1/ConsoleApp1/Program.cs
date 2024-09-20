using System;

public class Order
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public Order(string productName, int quantity, double price)
    {
        ProductName = productName;
        Quantity = quantity;
        Price = price;
    }
}

public class PriceCalculator
{
    public double CalculateTotalPrice(Order order)
    {
        return order.Quantity * order.Price * 0.9;
    }
}

public class PaymentProcessor
{
    public void ProcessPayment(string paymentDetails, double amount)
    {
        Console.WriteLine($"Payment of {amount:C} processed using: {paymentDetails}");
    }
}

public class NotificationService
{
    public void SendConfirmationEmail(string email)
    {
        Console.WriteLine($"Confirmation email sent to: {email}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Order order = new Order("Laptop", 2, 1500.00);
        
        PriceCalculator priceCalculator = new PriceCalculator();
        double totalPrice = priceCalculator.CalculateTotalPrice(order);
        
        PaymentProcessor paymentProcessor = new PaymentProcessor();
        paymentProcessor.ProcessPayment("Credit Card", totalPrice);
        
        NotificationService notificationService = new NotificationService();
        notificationService.SendConfirmationEmail("customer@example.com");
    }
}