namespace LLL2;

// Tips/Idé: Ändra namn på typen
// till PType eller liknande
// = tydligare + kan inte krocka
// med System.Type

// Valde att använda typ och storlek
// för både palltyp och hyllstorlek.
// Kan ev vara bättre att separera.
public enum Type
{
    Halv = 1,
    Hel = 2,
    None = 0
}

// Utkast för att kunna räkna med
// enums för hyllstorlek och pallkapacitet.
// Kan vara överflödigt efter omdesign.

// public static class CapacityOperations
// {
//   public static Type operator +(Type left, Type right)
//   {
//     return (Type)((int)left + (int)right);
//   }
// 
//   public static Type operator -(Type left, Type right)
//   {
//     return (Type)((int)left - (int)right);
//   }
// }