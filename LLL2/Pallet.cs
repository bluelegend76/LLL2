namespace LLL2;

// CAN HAS FUNNY LANGUAGES?
using System.Globalization;
using static Thread;
using System.Text;

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

        // TEST/TODO: Way of getting info about found/allotted slot back to constructor
        // i.e. using Slot.AdjustCapacity directly at construction of a Pallet
    }

    // Constructor used for adding some test pallets
    public Pallet(string palletID, Type palletType, string timeStamp)
    {
        PalletID = palletID;
        PalletType = palletType;
        TimeStamp = DateTime.Parse(timeStamp);
    }

    // LATER REFACTOR: May want to use a string as an ID template.
    // example: "aaa00000"
    private string GenerateID()
    {
        string idNum = $"{Storage.CurrentIDNum:D3}";
        var palletID = $"LL{idNum}";
        Storage.CurrentIDNum++;
        return palletID;
    }

    // TODO: May want to add field separator (ToString vs csv).
    public override string ToString()
    {
        CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");
        return $"  {PalletID} \t{PalletType} \t{TimeStamp}";
    }
}