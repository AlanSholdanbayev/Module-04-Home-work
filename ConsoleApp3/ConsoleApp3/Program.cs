using System;

public interface IPrinter
{
    void Print(string content);
}

public interface IScanner
{
    void Scan(string content);
}

public interface IFax
{
    void Fax(string content);
}

public class AllInOnePrinter : IPrinter, IScanner, IFax
{
    public void Print(string content)
    {
        Console.WriteLine("Printing: " + content);
    }

    public void Scan(string content)
    {
        Console.WriteLine("Scanning: " + content);
    }

    public void Fax(string content)
    {
        Console.WriteLine("Faxing: " + content);
    }
}

public class BasicPrinter : IPrinter
{
    public void Print(string content)
    {
        Console.WriteLine("Printing: " + content);
    }
}

public class Scanner : IScanner
{
    public void Scan(string content)
    {
        Console.WriteLine("Scanning: " + content);
    }
}

public class FaxMachine : IFax
{
    public void Fax(string content)
    {
        Console.WriteLine("Faxing: " + content);
    }
}

class Program
{
    static void Main(string[] args)
    {
        IPrinter printer = new BasicPrinter();
        printer.Print("Hello World!");

        IScanner scanner = new Scanner();
        scanner.Scan("Document.pdf");

        IFax faxMachine = new FaxMachine();
        faxMachine.Fax("Fax Document");
        
        AllInOnePrinter allInOnePrinter = new AllInOnePrinter();
        allInOnePrinter.Print("All-in-One Printing");
        allInOnePrinter.Scan("All-in-One Scanning");
        allInOnePrinter.Fax("All-in-One Faxing");
    }
}