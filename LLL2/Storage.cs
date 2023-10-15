namespace LLL2;

public class Storage
{
    // Initialize()
    private Slot[] _storage;

    // = new Slot[20];
    private readonly int _defaultCapacity = 20;
    // DONE: HashSet to hold unique ID:s.
    private static HashSet<string> _assignedIDs = new HashSet<string>();
    // _assignedIDs.UnionWith(x => new[] { x + "AB123", x + "BD234", x + "DE345" });

    public Storage()
    {
        _storage = new Slot[_defaultCapacity];
        for (var i = 0; i < _storage.Length; i++)
        {
            _storage[i] = new Slot();
        }

        // HACK: = Move to test-function.
        _storage[0].Items.Add(new Pallet("AB123", Type.Hel, "2023-09-15 17:05:32"));
        _storage[1].Items.Add(new Pallet("BD234", Type.Halv, "2023-09-15 17:05:32"));
        _storage[1].Items.Add(new Pallet("DE345", Type.Halv, "2023-09-15 17:05:32"));

        var testpalletsIDs = new string[] { "AB123", "BD234", "DE345" };
        foreach (var value in testpalletsIDs)
        {
            _assignedIDs.Add(value);
        }
        // _assignedIDs.UnionWith(x => new[] { x + "AB123", x + "BD234", x + "DE345" });
        // LATER: Possible checkup on ref in foreach loop
        // foreach (ref Slot slot in L3Storage)
        // {
        //     slot = new Slot();
        // }
        // return _storage;
    }

    // public void Add(Pallet pallet)
    // {
    //     _storage[0].Add = pallet;

    // Store()

    // NextAvailable()

    public static void Inventory(Storage storage)
    {
        Console.WriteLine(storage);
    }
    // TODO: Utilize three linked ToString-overrides.

    // Move()

    // Get()
    // TODO: Add case insensitivity.
    //  CalculateFee()
    // TODO: log to storage.log.csv

    // Optimize()/Pack()
    
    public override string ToString()
    {
        var n = 1;
        var result = "";
        result += "  ID\tTyp\tAnkom" + Environment.NewLine;
        result += "------------------------------------" + Environment.NewLine;
        foreach (var slot in _storage)
        {
            result += $"Plats {n}:" + Environment.NewLine;
            result += slot;
            n++;
        }
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