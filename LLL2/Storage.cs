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
        for (var i = 0; i < Slots.Length; i++)
        {
            Slots[i] = new Slot();
        }
        // LATER: Possible checkup on ref in foreach loop
        // foreach (ref Slot slot in _storage)
        // {
        //     slot = new Slot();
        //
        // +Suggested Workaround:
        //     Get the property that you want to modify by reference.
        //     ref var property = ref slot.Property;
        //
        //     Modify the property.
        //     property = newValue;
        // }
        // return _storage;

        // HACK: = Move to test-function.
        Slots[0].Items.Add(new Pallet("TT001", Type.Hel, "2023-09-15 17:48:20"));
        Slots[1].Items.Add(new Pallet("TT002", Type.Halv, "2023-09-15 10:30:10"));
        Slots[1].Items.Add(new Pallet("TT003", Type.Halv, "2023-09-15 17:05:00"));
        Slots[8].Items.Add(new Pallet("TT004", Type.Hel, "2023-09-25 10:25:05"));
        Slots[10].Items.Add(new Pallet("TT005", Type.Halv, "2023-09-14 12:20:32"));
        Slots[18].Items.Add(new Pallet("TT006", Type.Hel, "2023-07-31 13:08:32"));
        // _storage[18].Items.Add(new Pallet("YZ225", Type.Hel, "2023-07-41 17:05:32"));  // Sic
    }

    // Store()
    public void Store(Pallet pallet)
    {
        // _storage[0].Add = pallet;
    }
    // TODO: Get index of next slot, with Slot.CapacityLeft matching PalletType.

    public Slot NextAvailable(Storage storage, Pallet p)
    {
        // TODO: Possibly revert if-statement to reduce nesting.
        for (var i = 0; i < storage.Slots.Length; i++)
        {
            if (storage.Slots[i].CapacityLeft == p.PalletType)
            {
                return Slots[i];
                // break;
            }
        }

        return null;
    }
    
    public static void Show(Storage storage)
    {
        // Handled by ToString()-overrides in classes
        // Storage, Slot and Pallet.
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
        foreach (var slot in _storage)
        {
            result += $"Plats {n}:" + Environment.NewLine;
            result += slot;
            n++;
        }
        // foreach (var slot in _storage.Select((value, i) => new { value, i }))
        // {
        //     // use slot.value and slot.index in here
        // }
        return result;
        // for (var i = 0; i < _storage.Length; i++)
        // {
        //     result += $"Plats {i+1}:" + Environment.NewLine;
        //     result += _storage[i];
        //     // + Environment.NewLine;
        // }
        // Console.WriteLine(slot.ToString());
        // return result;
    }

}