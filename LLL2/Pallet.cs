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
    }

    public Pallet(string palletID, Type palletType, string timeStamp)
    {
        PalletID = palletID;
        PalletType = palletType;
        TimeStamp = DateTime.Parse(timeStamp);
    }

    // REFACTOR: May want to use a string as an ID template.
    // example: "aaa00000"
    // TODO: Ask .B how to implement according to above.
    // TODO: May want to test documentation comments (=three slashes).
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