namespace LLL2;

public class Slot
{
    // Initialize list to hold items for one storage slot.
    // TODO: Make Items private + rename to _slot(s)/_pallet(s)?.
    public List<Pallet> Items { get; set; } = new List<Pallet>();
    public Type CapacityLeft { get; set; } = Type.Hel;

    // IsAvailable()
    // = Match slot-capacity with Pallet Type
    // Store()/CanStore()  // Or move to different class?

    // REFACTOR: Generalize to work for both add and remove.
    public static void AdjustCapacity(Slot s, Pallet p)
    {
        s.CapacityLeft -= p.PalletType;
    }
    
    public static void AdjustCapacity(Slot s, Type type)
    {
        s.CapacityLeft -= type;
    }

    public override string ToString()
    {
        // Collect items in one slot
        // for later printing of storage.
        var result = "";
        foreach (var item in Items)
        {
            result += item + Environment.NewLine;
        }
        return result;
    }
}