namespace LLL2;

public class Storage
{
    private const int DefaultCapacity = 20;
    private readonly Slot[] _storage;
    private Slot[] Slots => _storage;
    public static int CurrentIDNum { get; set; } = 1;

    private Storage()
    {
        _storage = new Slot[DefaultCapacity];
        // TODO: May want to use _storage instead of Slots in the loop as well.
        for (var i = 0; i < Slots.Length; i++)
        {
            Slots[i] = new Slot();
        }

        // HACK: = Move to test-function +(!!) Adjust slot-capacity accordingly.
        Slots[0].Items.Add(new Pallet("TT001", Type.Hel, "2023-09-15 17:48:20"));
        Slots[1].Items.Add(new Pallet("TT002", Type.Halv, "2023-09-15 10:30:10"));
        Slots[1].Items.Add(new Pallet("TT003", Type.Halv, "2023-09-15 17:05:00"));
        Slots[8].Items.Add(new Pallet("TT004", Type.Hel, "2023-09-25 10:25:05"));
        Slots[10].Items.Add(new Pallet("TT005", Type.Halv, "2023-09-14 12:20:32"));
        Slots[18].Items.Add(new Pallet("TT006", Type.Hel, "2023-07-31 13:08:32"));
        // _storage[18].Items.Add(new Pallet("YZ225", Type.Hel, "2023-07-41 17:05:32"));  // Sic
    }

    private static void Menu()
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
        Console.WriteLine();  // \n (?)
        Console.Write("Ditt val: ");
    }

    public static void Run() {

        var l3Storage = new Storage();
        var run = true;
        while (run)
        {
            Menu();
 
            string choice = Console.ReadLine();
            Console.Clear();
                // Clearing the scrollback buffer
                // Console.WriteLine("\x1b[3J");
            var actions = new Dictionary<string, Action>
            {
                { "1", Store },
                { "2", Find },
                { "3", Move },
                { "4", () => Show(l3Storage) },
                { "5", Remove },
                { "6", Pack },
                { "0", () => { Console.WriteLine("Programmet avslutas. Välkommen tillbaka.");
                               run = false;
                               Environment.Exit(0); } },
            };
                // string choice = Console.ReadLine();
            if (actions.ContainsKey(choice))
            {
                actions[choice]();
            }
            else
            {
                Console.WriteLine("Ogiltigt val. Försök igen.");
            }
            // switch (choice)
            // {
            //     case "1":
            //         Store();
            //         break;
            //     case "2":
            //         Find();
            //         break;
            //     case "3":
            //         Move();
            //         break;
            //     case "4":
            //         Show(l3Storage);
            //         break;
            //     case "5":
            //         Remove();
            //         break;
            //     case "6":
            //         Pack();
            //         break;
            //     case "0":
            //         Console.WriteLine("Programmet avslutas. Välkommen tillbaka.");
            //         run = false;
            //         Environment.Exit(0);
            //         break;
            //     default:
            //         Console.WriteLine("Ogiltigt val. Försök igen.");
            //         break;
            //         // return 0;
            // }
        }
    }


    // Store()
    private static void Store()
    {
        // public void Store(Pallet p)
        Console.WriteLine("Stub for: Adding a pallet to inventory.");
        // _storage[0].Add = pallet;
        // TODO: Get index of next slot, with Slot.CapacityLeft matching PalletType.
        // if NextAvailable(p) == null
        //   No space available
        //   Tip: Try packing the storage
    }

    private Slot NextAvailable(Pallet p)
    {
        // TODO: Possibly (and if feasible) revert if-statement to reduce nesting.
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

    private static void Show(Storage storage)
    {
        // TODO?: Move report header and separator for ToString()-overrides to here.
        // Handled by ToString()-overrides
        // in classes Storage, Slot and Pallet.
        Console.WriteLine(storage);
        Console.ReadKey();
    }

    private static void Find()
    {
        Console.WriteLine("Stub for: Find pallet in storage.");
        // Console.Write("Ange pall-ID: ");
        // TODO: Add case insensitivity.
        // Test pattern with Regex: ^[A-Z]{2}[0-9]{3}$
        // string palletID = Console.ReadLine();
        // TODO: Test using LinQ to search for PalletID.
        // or return null/-1 if pallet not found
    }

    private static void Move()
    {
        Console.WriteLine("Stub for: Move pallet.");
        // Find(palletID)
        // if Slot.CapacityLeft < p.PalletType
        //   Add pallet to slot
        // else
        //   "Could not move to that slot"
    }

    // GetPallet() Fetch() Deliver()
    private static void Remove()
    {
        Console.WriteLine("Stub for: Remove.");
        // Find(palletID)
        //  CalculateFee()
        // TODO: log to checkouts.log.csv
    }

    // Optimize()
    private static void Pack()
    {
        Console.WriteLine("Stub for: Pack storage.");
        // report slots with only one half-pallet stored
        // if list of found slots contains odd number (larger than 1)
        //   shave off last slot
        //   move slots(nums?) to temporary list; then
        //   pick half-pallets in pairs from temporary list
        //+  Add back half-pallets to first available slot in storage
        //     OR
        //   Get first slot with Slot.CapacityLeft == Halv
        //   get pallet from next slot with Slot.CapacityLeft == Halv
        //   Try using Move for this purpose (+possibly recursive solution)
    }
    
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