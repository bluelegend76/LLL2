namespace LLL2;

public class Storage
{
    // Initialize()
    // private Slot[] _storage = new Slot[20];
    public static Slot[] L3Storage = new Slot[20];

    // meningar=is/as stycken=ip/ap ord=iw/aw kodblock=b / iB/aB
    public static void Initialize()
    {
        foreach (var slot in L3Storage)
        {
            slot.Items = new List<Pallet>();
        }
        L3Storage[0].Items.Add(new Pallet("AB123", Type.Hel));
        L3Storage[1].Items.Add(new Pallet("BD234", Type.Hel));
        L3Storage[4].Items.Add(new Pallet("CB123", Type.Hel));
        L3Storage[8].Items.Add(new Pallet("XX672", Type.Halv));
        L3Storage[10].Items.Add(new Pallet("YY423", Type.Halv));
        L3Storage[18].Items.Add(new Pallet("YZ225", Type.Halv));
            // = new Pallet("AB123", Type.Hel);
        // return _storage;
    }
    // l3Storage[0].Add = new Pallet();

    // lllStorage[0]  = "LL001\tHel\t2023-08-01\t12:00:00";
    // lllStorage[2]  = "LL003\tHalv\t2023-08-10\t12:30:00";
    // lllStorage[5]  = "LL004\tHel\t2023-08-14\t12:24:00";
    // lllStorage[8]  = "LL007\tHalv\t2023-09-01\t12:48:00";
    // lllStorage[10] = "LL009\tHel\t2023-09-24\t14:50:00";
    // lllStorage[18] = "LL017\tHalv\t2023-09-14\t16:24:00";
    // return lllStorage;

    // Store()
    // TODO: Initialize HashSet to hold unique ID:s.

    // NextAvailable()

    // Inventory()

    // Move()

    // Get()

    // Optimize()
}