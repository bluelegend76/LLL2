namespace LLL2;

internal class L3Storage
{
    /*** LLL Storage 2
     * D. Albertsson BUV23
     ***/

    public static void Main()
    {
        // var l3Storage = new Storage();
        // l3Storage.Initialize();
        new Storage();
        Storage.Initialize();
        Menu();
        // var storage = new L3Storage();
        // storage.Run();
    }

    public static void Menu()
    {
        Console.Clear();
        Console.WriteLine("---- Lunds Långlager 2 ----");
        Console.WriteLine("\r\nHuvudmeny:");
        Console.WriteLine("1) Registrera en pall");
        Console.WriteLine("2) Sök pall i lager");
        Console.WriteLine("3) Visa lagret");
        Console.WriteLine("4) Lämna ut en pall");
        Console.WriteLine("0) Avsluta");
        Console.Write("\r\nDitt val: ");
    }
}