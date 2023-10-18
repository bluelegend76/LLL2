namespace LLL2;

public class Slot
{
    // Initialize list to hold items for one storage slot.
    // TODO: Make Items private + rename to _slot(s)/_pallet(s)?.
    public List<Pallet> Items = new List<Pallet>();
    public Type CapacityLeft { get; private set; } = Type.Hel;

    // public Slot()
    // {
    //     Pallets = new List<Pallet>();
    // }
    // = new List<Pallet>();

    // IsAvailable()
    // = Match slot-capacity with Pallet Type
    // TODO: NextMatching()/NextAvailable()
    // + match with capacity

    // Store()/CanStore()  // Or move to different class?

    public void AdjustCapacity(Slot s, Pallet p)
    {
        s.CapacityLeft -= p.PalletType;
    }

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