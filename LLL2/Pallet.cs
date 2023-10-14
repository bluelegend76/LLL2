namespace LLL2;

public class Pallet
{
    public string PalletID { get; set; }
    public Type PalletType { get; set; }
    public DateTime TimeStamp { get; set; }

    public Pallet(string palletID, Type palletType)
    {
        PalletID = palletID;
        PalletType = palletType;
        TimeStamp = DateTime.Now;
    }

    public Pallet(string palletID, Type palletType, string timeStamp)
    {
        PalletID = palletID;
        PalletType = palletType;
        TimeStamp = DateTime.Parse(timeStamp);
    }

    // public static string GenerateID()
    // {
    //     
    // }
}