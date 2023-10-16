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
            // l3Storage[0].Items.Add(new Pallet("AB123", Type.Hel, "2023-09-15 17:05:32"));
            // l3Storage[1].Items.Add(new Pallet("BD234", Type.Hel, "2023-09-20 17:05:32"));
            // l3Storage[4].Items.Add(new Pallet("CB123", Type.Hel, "2023-09-23 17:05:32"));
            // l3Storage[8].Items.Add(new Pallet("XX672", Type.Halv, "2023-09-25 17:05:32"));
            // l3Storage[10].Items.Add(new Pallet("YY423", Type.Halv, "2023-09-14 17:05:32"));
            // l3Storage[18].Items.Add(new Pallet("YZ225", Type.Halv, "2023-07-41 17:05:32"));  // Sic
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
        options.ForEach(option => Console.WriteLine(option));
        Console.WriteLine();
        Console.Write("Ditt val: ");
    }
}