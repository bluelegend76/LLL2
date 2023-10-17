namespace LLL2;

internal class L3Storage
{
    /*************** LLL Storage 2 *******************
     *             D. Albertsson BUV23
     * "Completely Ridiculously Awesome Pallet-Handler"
     *     - a modestly advanced Storage Utility -
     *               ( aka C.R.A.P. )
     *************************************************/

    public static void Main()
    {
          // l3Storage.Initialize();
        var l3Storage = new Storage();
          // Console.WriteLine(l3Storage);
        Storage.Show(l3Storage);
        Console.ReadKey();
        // l3Storage.NextAvailable(l3Storage, new Pallet(10, 10, 10, 10, 10));
        Menu();
    }

    // TODO: Move out to own class?
    public static void Menu()
    {
        var options = new List<string> {
          "1) Registrera en pall",
          "2) Sök pall i lager",
          "3) Flytta pall",
          "4) Visa lagret",
          "5) Lämna ut en pall",
          "6) Optimera/Packa lagret",
          "0) Avsluta"
        };

        Console.Clear();
        Console.WriteLine("---- L3 Storage ----");
        Console.WriteLine();
        Console.WriteLine("Huvudmeny:");
        // Using a method group instead of a lambda expression
        options.ForEach(Console.WriteLine);
          // options.ForEach(option => Console.WriteLine(option));
        Console.WriteLine();
        Console.Write("Ditt val: ");
    }
}