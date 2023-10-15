namespace LLL2;

public class Slot
{
    // Initialize list to hold items for one storage slot.
    // TODO: Make Items private + rename to _slot(s).
    public List<Pallet> Items = new List<Pallet>();
    // public List<Pallet> ASlot = new List<Pallet>();
    public Type Capacity { get; set; } = Type.Hel;
      // public static List<Pallet> Init() => new List<Pallet>();
    // public Slot()
    // {
    //     Items = new List<Pallet>();
    // }
    // = new List<Pallet>();

    // IsAvailable()
    // = Match slot-capacity with Pallet Type
    // TODO: NextMatching()/NextAvailable()
    // + match with capacity

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