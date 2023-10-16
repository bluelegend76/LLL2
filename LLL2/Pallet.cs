namespace LLL2;

// CAN HAS FUNNY LANGUAGES?
using System.Globalization;
using System.Text;
using static Thread;

public class Pallet
{
    string PalletID { get; set; }
    public Type PalletType { get; set; }
    public DateTime TimeStamp { get; set; }

    public Pallet(Type palletType)
    {
        // PalletID = GenerateID();
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
    public static string GenerateID()
    {
    // UNTIL ID IS UNIQUE:
    // TODO: Use 'LL' + Incrementer Instead[!!]
        return String.Empty;
    }

    public override string ToString()
    {
        CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");
        return $"  {PalletID} \t{PalletType} \t{TimeStamp}";
    }
}