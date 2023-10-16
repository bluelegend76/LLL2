namespace LLL2;

public class Slot
{
    // Initialize list to hold items for one storage slot.
    // TODO: Make Items private + rename to _slot(s)?.
    public List<Pallet> Items = new List<Pallet>();
    // Pallets[!!]
    public Type CapacityLeft { get; set; } = Type.Hel;
    // REFACTOR?: FreeCapacity
      // public static List<Pallet> Init() => new List<Pallet>();
    // public Slot()
    // {
    //     Pallets = new List<Pallet>();
    // }
    // = new List<Pallet>();

    // IsAvailable()
    // = Match slot-capacity with Pallet Type
    // TODO: NextMatching()/NextAvailable()
    // + match with capacity

    // AdjustCapacity(Slot s)

    public override string ToString()
    {
        var result = "";
        foreach (var item in Items)
        {
            result += item + Environment.NewLine;
        }
        return result;
    }
}