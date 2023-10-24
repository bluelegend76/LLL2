namespace LLL2;

// REFACTOR: Adding automatic adjustment
// when pallet gets added to/pulled from a slot.
// May want to try inheritance, composition
// or event-signaling via a delegate.
public class Pallet
{
    public string PalletID { get; private set; }
    public Type PalletType { get; private set; }
    public DateTime TimeStamp { get; private set; }

    public Pallet(Type palletType)
    {
        PalletID = GenerateID();
        PalletType = palletType;
        TimeStamp = DateTime.Now;
    }

    // Constructor used for adding some test pallets.
    public Pallet(string palletID, Type palletType, string timeStamp)
    {
        PalletID = palletID;
        PalletType = palletType;
        TimeStamp = DateTime.Parse(timeStamp);
    }

    // Possible Tip: Investigate 'Formatstring Registering'.
    private string GenerateID()
    {
        string idNum = $"{Storage.CurrentIDNum:D3}";
        var palletID = $"LL{idNum}";
        Storage.CurrentIDNum++;
        return palletID;
    }

    public override string ToString()
    {
        CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");
        return $"  {PalletID} \t{PalletType} \t{TimeStamp}";
    }
}