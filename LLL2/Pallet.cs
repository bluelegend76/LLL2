namespace LLL2;

// CAN HAS FUNNY LANGUAGES?
using System.Globalization;
using static Thread;

public class Pallet
{
    string PalletID { get; set; }
    public Type PalletType { get; set; }
    public DateTime TimeStamp { get; set; }

    public Pallet(string palletID, Type palletType)
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
    // TODO: Ask .B how to implement according to above.
    // public static string GenerateID()
    // {
    //     Random rnd = new Random();
    //     StringBuilder sb = new StringBuilder();
    //
    //     for (int i = 0; i < 2; i++)
    //     {
    //         char rndChar = (char)('A' + rnd.Next(26));
    //         char rndChar = (char)('A' + rnd.Next(65, 90));
    //         sb.Append(randChar);
    //     }
    //     for (int i = 0; i < 3; i++)
    //     {
    //         int randInt = rnd.Next(1000);
    //         sb.Append(randInt);
    //     }
    //     return sb.ToString();
    // }

    public override string ToString()
    {
        CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");
        return $"  {PalletID}\t{PalletType}\t{TimeStamp}";
    }
}