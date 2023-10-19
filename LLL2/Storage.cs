namespace LLL2;

using System.Text.RegularExpressions;

public class Storage
{
    private const int DefaultCapacity = 20;

    private static Slot[]? Slots { get; set; }

    public static int CurrentIDNum { get; set; } = 1;

    private Storage()
    {
        Slots = new Slot[DefaultCapacity];
        // TODO: May want to use _storage instead of Slots in the loop as well.
        for (var i = 0; i < Slots.Length; i++)
        {
            Slots[i] = new Slot();
        }
 
        // HACK: = Move to test-function +(!!) Adjust slot-capacity accordingly.
        Slots[0].Items.Add(new Pallet("TT001", Type.Hel, "2023-09-15 17:48:20"));
        Slot.AdjustCapacity(Slots[0], Slots[0].Items[0]);
        Slots[1].Items.Add(new Pallet("TT002", Type.Halv, "2023-09-15 10:30:10"));
        Slot.AdjustCapacity(Slots[1], Slots[1].Items[0]);
        Slots[1].Items.Add(new Pallet("TT003", Type.Halv, "2023-09-15 17:05:00"));
        Slot.AdjustCapacity(Slots[1], Slots[1].Items[1]);
        Slots[8].Items.Add(new Pallet("TT004", Type.Hel, "2023-09-25 10:25:05"));
        Slot.AdjustCapacity(Slots[8], Slots[8].Items[0]);
        Slots[10].Items.Add(new Pallet("TT005", Type.Halv, "2023-09-14 12:20:32"));
        Slot.AdjustCapacity(Slots[10], Slots[10].Items[0]);
        Slots[18].Items.Add(new Pallet("TT006", Type.Hel, "2023-07-31 13:08:32"));
        Slot.AdjustCapacity(Slots[18], Slots[18].Items[0]);
        // Slot.AdjustCapacity(Slots[0], new Pallet("TT001", Type.Hel, "2023-09-15 17:48:20"));
        // Slot.AdjustCapacity(Slots[1], new Pallet("TT002", Type.Halv, "2023-09-15 10:30:10"));
        // Slot.AdjustCapacity(Slots[1], new Pallet("TT003", Type.Halv, "2023-09-15 17:05:00"));
        // Slot.AdjustCapacity(Slots[8], new Pallet("TT004", Type.Hel, "2023-09-25 10:25:05"));
        // Slot.AdjustCapacity(Slots[10], new Pallet("TT005", Type.Halv, "2023-09-14 12:20:32"));
        // Slot.AdjustCapacity(Slots[18], new Pallet("TT006", Type.Hel, "2023-07-31 13:08:32"));
        // _storage[18].Items.Add(new Pallet("YZ225", Type.Hel, "2023-07-41 17:05:32"));  // Sic
    }

    private static void AddTestPallets()
    {
        // for i in positions-Array
        //   unpack tuples of pallet-info in palletsinfo-array
        //   Add new testpallet
        //   +call Slot.AdjustCapacity
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

        // TODO: var l3Storage may be redundant
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
                { "2", () => Find() },
                { "3", Move },
                { "4", () => Show(l3Storage) },
                { "5", Remove },
                { "6", Pack },
                { "0", () => { Console.WriteLine("Pallar du inte mer? KTHXBYE! %}");
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


    private static void Store()
    {
        Console.WriteLine("Lagra en pall ---- ");
        Console.Write("Ange palltyp [ 1 = Halv  2 = Hel ]: ");
        string? type = Console.ReadLine();

        Type palletType = Type.None;
        while (true)
        {
            switch (type)
            {
                case "1":
                    palletType = Type.Halv;
                    break;
                case "2":
                    palletType = Type.Hel;
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
            }

            break;
        }

        Slot slot = NextAvailable(palletType);
        if (slot == null)
        {
            Console.WriteLine("Ingen plats tillgänglig.");
            Console.WriteLine("Tips: Prova att packa lagret.");
        }
        else
        {
            slot.Items.Add(new Pallet(palletType));
            Slot.AdjustCapacity(slot, palletType);
            var storageSpot = Array.IndexOf(Slots, slot) + 1;
            Console.WriteLine($"Pallen lades till på plats {storageSpot}");
        }

        Console.ReadKey();
    }

    private static Slot NextAvailable(Type type)
    {
        // Using LinQ: return Slots.FirstOrDefault(slot => slot.CapacityLeft >= pallet.PalletType);
        // Note: Possibly (+if feasible) revert if-statement to reduce nesting.
        foreach (var slot in Slots)
        {
            if (slot.CapacityLeft >= type)
            {
                return slot;
                // break;
            }
        }

        return null;
    }

    // TODO: Sending in Storage is probably superfluous
    private static void Show(Storage storage)
    {
        // TODO?: Move report header and separator for ToString()-overrides to here.
        // Handled by ToString()-overrides
        // in classes Storage, Slot and Pallet.
        Console.WriteLine(storage);
        Console.ReadKey();
    }

    private static (Pallet? pallet, Slot? slot) Find()
    {
        // TODO? Print "Sök efter en pall"
 
        string? query;
        bool IsValidID(string? s) => !string.IsNullOrEmpty(query)
                                     && Regex.IsMatch(query, "^[A-Za-z]{2}[0-9]{3}$");
        while (true)
        {
            Console.Write("Ange pall-ID: ");
            query = Console.ReadLine();

            if (IsValidID(query))
            {
                break;
            }
        
            Console.WriteLine("Ogiltigt ID. Försök igen.");
            Console.ReadKey();
            Console.Clear();
        }
        // while (true)
        // {
        //     Console.Write("Ange pall-ID: ");
        //     query = Console.ReadLine();

        //     if (string.IsNullOrEmpty(query))
        //     {
        //         Console.WriteLine("Ogiltigt ID. Försök igen.");
        //         continue;
        //     }
        //     
        //     if (Regex.IsMatch(query, "^[A-Z]{2}[0-9]{3}$"))
        //     {
        //         break;
        //     }

        //     Console.WriteLine("Ogiltigt ID. Försök igen.");
        // }
        var palletID = query.ToUpper();

        (Pallet? pallet, Slot? slot) ps = (null, null);
        // foreach (var s in Slots)
        // {
        //   (ps.pallet, ps.slot) = (s.Items.Find(p => p.PalletID == palletID), s);
        // }
        // (Pallet? pallet, Slot? slot) ps = (null, null);

        foreach (var s in Slots)
        {
            // if (s.Items.Find(p => p.PalletID == palletID) is not { } foundPallet) continue;
            // ps = (foundPallet, s);
            // break;
            var foundPallet = s.Items.Find(p => p.PalletID == palletID);
            if (foundPallet is null)
            {
                continue;
            }
            ps = (foundPallet, s);
            break;
        }

        // if (pallet != null)
        // {
        //   // Do something with the pallet and slot.
        // }
        // Pallet? pallet = null;
        // foreach (var slot in Slots)
        // {
        //     pallet = slot.Items.Find(p => p.PalletID == palletID);
        // }
        
        if (ps.pallet == null)
        {
            Console.WriteLine($"Pallen {palletID} hittades inte.");
        }
        else
        {
            var storageSpot = Array.IndexOf(Slots, ps.slot) + 1;
            Console.WriteLine($"Pallen {palletID} finns på plats {storageSpot}.");
        }
        Console.ReadKey();
        // Console.WriteLine(ps.pallet == null
        //     ? $"Pallen {palletID} hittades inte."
        //     : $"Pallen {palletID} finns på plats .");
        // Console.ReadKey();
        
        return (ps.pallet, ps.slot);
        // or return null/-1 if pallet not found
    }

    private static void Move()
    {
        // TODO: Print "Flytta en pall ----"
        Find();
        // !IsNullOrEmpty
        // if Slot.CapacityLeft < p.PalletType
        //   Add pallet to slot
        // else
        //   "Could not move to that slot"
    }

    // GetPallet() Fetch() Deliver()
    private static void Remove()
    {
        Console.WriteLine("Leverera pall ----");
        Find();
        //  CalculateFee()
        // TODO: log to checkouts.log.csv
        // The actual remove
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