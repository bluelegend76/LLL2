namespace LLL2;

public class Storage
{
    private const int DefaultCapacity = 20;
    private readonly Slot[] _storage;
    public Slot[] Slots => _storage;
    public static int CurrentIDNum { get; set; } = 1;

    public Storage()
    {
        _storage = new Slot[DefaultCapacity];
        // TODO: May want to use _storage instead of Slots in the loop as well.
        for (var i = 0; i < Slots.Length; i++)
        {
            Slots[i] = new Slot();
        }

        // HACK: = Move to test-function.
        Slots[0].Items.Add(new Pallet("TT001", Type.Hel, "2023-09-15 17:48:20"));
        Slots[1].Items.Add(new Pallet("TT002", Type.Halv, "2023-09-15 10:30:10"));
        Slots[1].Items.Add(new Pallet("TT003", Type.Halv, "2023-09-15 17:05:00"));
        Slots[8].Items.Add(new Pallet("TT004", Type.Hel, "2023-09-25 10:25:05"));
        Slots[10].Items.Add(new Pallet("TT005", Type.Halv, "2023-09-14 12:20:32"));
        Slots[18].Items.Add(new Pallet("TT006", Type.Hel, "2023-07-31 13:08:32"));
        // _storage[18].Items.Add(new Pallet("YZ225", Type.Hel, "2023-07-41 17:05:32"));  // Sic
    }

    public static void Menu()
    {
        var options = new List<string>
        {
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

    public static void Run() {

        var run = true;
        while (run)
        {
            Menu();
            string choice = Console.ReadLine();

            Console.Clear();
            switch (choice)
            {
                case "1":
                    // Store(inventory);
                    Console.WriteLine("Val 1");
                    break;
                case "2":
                    Console.WriteLine("Val 2");
                    // Find(inventory);
                    break;
                case "3":
                    Console.WriteLine("Val 2");
                    // Find(inventory);
                    break;
                case "4":
                    Console.WriteLine("Val 3");
                    // Show(inventory);
                    break;
                case "5":
                    Console.WriteLine("Val 4");
                    // Remove(inventory);
                    break;
                case "6":
                    Console.WriteLine("Val 4");
                    // Pack(inventory);
                    break;
                case "0":
                    Console.WriteLine("Programmet avslutas. Välkommen tillbaka.");
                    run = false;
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
                    // return 0;
                // TODO: Dictionary variant suggested by Bard
                // public static void Run()
                // {
                //     var run = true;
                //     var actions = new Dictionary<string, Action>
                //     {
                //         { "1", Store },
                //         { "2", Find },
                //         { "3", Find },
                //         { "4", Show },
                //         { "5", Remove },
                //         { "6", Pack },
                //         { "0", () => { run = false; Environment.Exit(0); } }
                //     };
                // 
                //     while (run)
                //     {
                //         Menu();
                //         string choice = Console.ReadLine();
                // 
                //         Console.Clear();
                //         Action action;
                //         if (actions.TryGetValue(choice, out action))
                //         {
                //             action();
                //         }
                //         else
                //         {
                //             Console.WriteLine("Ogiltigt val. Försök igen.");
                //         }
                //     }
                // }
            }
        }
    }


    // Store()
    public void Store(Pallet p)
    {
        
        // _storage[0].Add = pallet;
    }
    // TODO: Get index of next slot, with Slot.CapacityLeft matching PalletType.

    public Slot NextAvailable(Pallet p)
    {
        // TODO: Possibly (+if feasible) revert if-statement to reduce nesting.
        foreach (var slot in Slots)
        {
            if (slot.CapacityLeft == p.PalletType)
            {
                return slot;
                // break;
            }
        }

        return null;
    }

    public static void Show(Storage storage)
    {
        // TODO?: Move report header and separator for ToString()-overrides to here.
        // Handled by ToString()-overrides
        // in classes Storage, Slot and Pallet.
        Console.WriteLine(storage);
    }

    // (Item)Search/Find()
    // TODO: Use LinQ to search for PalletID.

    // Move()

    // Get()  GetPallet()
    // Fetch()   Deliver()
    // Remove()
    // TODO: Add case insensitivity.
    //  CalculateFee()
    // TODO: log to storage.log.csv

    // Optimize()/Pack()
    
    public override string ToString()
    {
        var n = 1;
        var result = "";
        result += "  ID \tTyp \tAnkom" + Environment.NewLine;
        result += "------------------------------------" + Environment.NewLine;
        foreach (var slot in Slots)
        {
            result += $"Plats {n}:" + Environment.NewLine;
            result += slot;
            n++;
        }
        // foreach (var slot in Slots.Select((value, i) => new { value, i }))
        // {
        //     // use slot.value and slot.index in here
        // }
        return result;
        // for (var i = 0; i < Slots.Length; i++)
        // {
        //     result += $"Plats {i+1}:" + Environment.NewLine;
        //     result += Slots[i];
        //     // + Environment.NewLine;
        // }
        // Console.WriteLine(slot.ToString());
        // return result;
    }

}