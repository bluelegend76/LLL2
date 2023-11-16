namespace LLL2;

using System.Text.RegularExpressions;

// NOTE TO SELF: May want to test adding documentation comments (=three slashes).
public class Storage
{
    private const int DefaultCapacity = 20;

    // Flera sättningar av grundläggande inställningar
    // för klasserna experimentella för nuvarande
    // (=nullable eller inte mm)
    private static Slot[]? Slots { get; set; }

    // Seed for generating number part of Pallet ID
    public static int CurrentIDNum { get; set; } = 1;

    private Storage()
    {
        Slots = new Slot[DefaultCapacity];

        // Initialize storage array with slot-lists.
        for (var i = 0; i < Slots.Length; i++)
        {
            Slots[i] = new Slot();
        }
 
        // HACK: Move to separate test-function later.
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
        // ----
        // Two pallets used for testing the Pack-method:
        // Slots[12].Items.Add(new Pallet("TT007", Type.Halv, "2023-09-15 17:05:00"));
        // Slot.AdjustCapacity(Slots[12], Slots[12].Items[0]);
        // Slots[16].Items.Add(new Pallet("TT008", Type.Halv, "2023-09-14 12:20:32"));
        // Slot.AdjustCapacity(Slots[16], Slots[16].Items[0]);
    }

    // private static void AddTestPallets()
    // {
         // Snags and unclear implementation at first design-stage.
    // }
    
    private static void Menu()
    {
        var options = new List<string>
        {
            // Tip/Idea: Merging Menu and Switch into an Object
            // + generate numbering for menu.
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

        // TODO: var l3Storage may be redundant
        var l3Storage = new Storage();
        var run = true;
        while (run)
        {
            Menu();
 
            string choice = Console.ReadLine();
            Console.Clear();
            // Valde att testa en dictionary-lösning
            // vilket blev väldigt koncist.
            var actions = new Dictionary<string, Action>
            {
                { "1", Store },
                { "2", () => Search() },
                { "3", Move },
                { "4", () => Show(l3Storage) },
                { "5", Deliver },
                { "6", Pack },
                { "0", () => { Console.WriteLine("Pallar du inte längre? Ha det fint.");
                               run = false;
                               Environment.Exit(0); } },
            };

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
            //         Search();
            //         break;
            //     case "3":
            //         Move();
            //         break;
            //     case "4":
            //         Show(l3Storage);
            //         break;
            //     case "5":
            //         Deliver();
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


    // Tips/Idé: Plocka ut att ta input från användaren
    // till separat metod.
    private static void Store()
    {
        Console.WriteLine("Lagra en pall ---- ");
        Console.Write("Välj palltyp [ 1 = Halv 2 = Hel ]: ");
        string? type = Console.ReadLine();

        Type palletType;
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
                    type = Console.ReadLine();
                    continue;
            }

            // // Validate the pallet type
            // if (palletType == Type.None)
            // {
            //     Console.WriteLine("Ogiltigt val. Försök igen.");
            //     type = Console.ReadLine();
            //     continue;
            // }

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
            // Save number for storage spot
            // i.e. one higher than storage spot.
            var storageSpot = Array.IndexOf(Slots, slot) + 1;
            Console.WriteLine($"Pallen lades till på plats {storageSpot}");
        }

        Console.ReadKey();
    }

    private static Slot NextAvailable(Type type)
    {
        // Tip/Note on using LinQ: return Slots.FirstOrDefault(slot => slot.CapacityLeft >= pallet.PalletType);
        foreach (var slot in Slots)
        {
            if (slot.CapacityLeft >= type)
            {
                return slot;
            }
        }

        // If no slot can hold pallet.
        return null;
    }

    // TODO: Sending in storage is probably superfluous
    private static void Show(Storage storage)
    {
        // TODO: Move report header and separator for ToString()-overrides to here?

        // Handled by ToString()-overrides
        // in classes Storage, Slot and Pallet respectively.
        Console.WriteLine(storage);
        Console.ReadKey();
    }

    // REFACTOR: Returns pallet and slot
    // to match current signature of Search()
    // TODO Important: Correct incorrect adding of 'Pallet=None'
    private static (Pallet? pallet, Slot? slot) Search()
    {
        string? query;
        // Possible REFACTOR: Separate out to
        // a validation method, that takes
        // criteria as parameters.
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

        // TODO: May want to use case insensitive
        // string-match instead.
        var palletID = query.ToUpper();

        (Pallet? pallet, Slot? slot) ps = (null, null);

        foreach (var s in Slots)
        {
            var foundPallet = s.Items.Find(p => p.PalletID == palletID);
            if (foundPallet is null)
            {
                continue;
            }
            ps = (foundPallet, s);
            break;
        }

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
        
        return (ps.pallet, ps.slot);
    }

    private static void Move()
    {
        Console.WriteLine("Flytta en pall ----");

        // Using variable deconstruction to get
        // values from Pallet-search.
        var (foundPallet, foundSlot) = Search();
        
        if (foundSlot != null && foundPallet != null)
        {
            Console.WriteLine($"Plats att flytta till [1-{DefaultCapacity}]:");

            var input = "";
            while (true)
            {
              input = Console.ReadLine();

              // Testade null-coalescing-operatorn
              // för att lära om den
              if ((input ?? "").Length == 0 || !Regex.IsMatch(input, "^([1-9]|1[0-9]|20)$"))
              {
                Console.WriteLine("1 till 20. Prova igen.");
                continue;
              }

              break;
            }

            var targetSpot = int.Parse(input);
            var targetIndex = targetSpot - 1;
            // Save target-slot as opposed to its index.
            var targetSlot = Slots[targetIndex];

            if (targetSlot.CapacityLeft >= foundPallet.PalletType)
            {
                // TODO: Implement capacity adjustment
                // of slot with boolean flag
                // directly when adding/removing a pallet.
                // Current solution very ad hoc.
                targetSlot.Items.Add(foundPallet);
                Slot.AdjustCapacity(targetSlot, foundPallet);
                foundSlot.Items.Remove(foundPallet);
                targetSlot.CapacityLeft = (foundPallet.PalletType == Type.Hel)
                    ? Type.None
                    : Type.Halv;
                Console.WriteLine($"Pallen flyttad till plats {targetSpot}.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"För lite utrymme på plats {targetSpot}.");
                Console.ReadKey();
            }
        }
    }
    
    private static void Deliver()
    {
        CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");

        Console.WriteLine("Leverera pall ----");
        var (foundPallet, foundSlot) = Search();
        if (foundSlot != null && foundPallet != null)
        {
            // Report days + hours in storage
            Console.WriteLine($"Lämnar ut pall {foundPallet.PalletID}.");

            var now = DateTime.Now;
            // Delta time for register-time and delivery-time
            var timeInStorage = now - foundPallet.TimeStamp;

            // TODO: Already implemented in DateTime?
            var dayDays = (timeInStorage.Days == 1)
                ? "dag"
                : "dagar";
            var hourHours = (timeInStorage.Hours == 1)
                ? "timme"
                : "timmar";
            Console.WriteLine(
                $"Pallen har varit i lager {timeInStorage.Days} {dayDays} och {timeInStorage.Hours} {hourHours}.");

            // Should be pulled to separate method CalculateFee()
            double hourlyFee = (foundPallet.PalletType == Type.Hel)
                ? 75.0
                : 39.0;
            var costTotal = Math.Ceiling(timeInStorage.TotalHours) * hourlyFee;
            Console.WriteLine($"Kostnaden blev {costTotal:C2}.");

            var p = foundPallet;  // Convenience variable.
            // TODO: Move logging to separate method.
            const string logPath = @"..\..\..\checkouts-log.csv";
            using (var sw = new StreamWriter(logPath, true))
            {
                sw.WriteLine($"id{p.PalletID},typ,{p.PalletType},ankom,{p.TimeStamp},utlämnad,{now},tid i lagret,{timeInStorage.Days} {dayDays} {timeInStorage.Hours} {hourHours},kostnad,{costTotal:C2}");
            }

            // Removing the pallet from storage
            foundSlot.Items.Remove(foundPallet);
            foundSlot.CapacityLeft = (foundPallet.PalletType == Type.Hel)
                ? Type.None
                : Type.Halv;

            Console.ReadKey();
        }
    }

    // Pack/Optimize storage
    // (i.e. no half-sized alone in one slot)
    private static void Pack()
    {
        // List for collecting up lone half-pallets
        var halfSizeOrphans = new List<Pallet>();
        foreach (var slot in Slots)
        {
            // Collect up orphan half-sized
            if (slot.Items.Count == 1 && slot.CapacityLeft == Type.Halv)
            {
                halfSizeOrphans.Add(slot.Items[0]);
                slot.CapacityLeft = Type.Hel;
                slot.Items.RemoveAt(0);
            }
        }

        // Put orphan half-sized pallets back into storage
        foreach (var hp in halfSizeOrphans)
        {
            Slot nextAvailableSlot = NextAvailable(hp.PalletType);
            nextAvailableSlot.Items.Add(hp);
            Slot.AdjustCapacity(nextAvailableSlot, hp);
        }
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
        return result;
    }

}