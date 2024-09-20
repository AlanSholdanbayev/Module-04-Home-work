using System;

public interface INotifier
{
    void SendNotification(string message);
}

public class EmailSender : INotifier
{
    public void SendNotification(string message)
    {
        Console.WriteLine("Email sent: " + message);
    }
}

public class SmsSender : INotifier
{
    public void SendNotification(string message)
    {
        Console.WriteLine("SMS sent: " + message);
    }
}

public class NotificationService
{
    private readonly INotifier[] _notifiers;

    public NotificationService(INotifier[] notifiers)
    {
        _notifiers = notifiers;
    }

    public void Send(string message)
    {
        foreach (var notifier in _notifiers)
        {
            notifier.SendNotification(message);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        INotifier[] notifiers = { new EmailSender(), new SmsSender() };
        NotificationService notificationService = new NotificationService(notifiers);

        notificationService.Send("Hello, this is a notification!");
    }
}