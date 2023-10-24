namespace LLL2;

/* Kommentarer om projektet:
   Jag har inte alltid prioriterat att konsekvent
   använda samma tillvägagångssätt på alla ställen,
   utan ibland valt att testa och utforska några olika
   sätt, t.ex. försöka prova att använda '??'-operatorn,
   lambdas mm, för att lära mig mer om dem
   och därigenom "utvidga verktygslådan",
   utom om de olika omskrivningarna och metoderna blivit
   alldeles uppenbart tillkrånglade eller kryptiska.
   
   Min utgångspunkt var också att försöka göra en utformning
   (=klasserna Storage, Slot, och Pallet) som skulle kunna
   gå att bygga ut och bygga vidare på senare.
   
   Flera metoder blev dock stora och gjorde flera saker,
   vilket jag skulle vilja plocka isär och göra en ny
   version på framgent.
*/

internal class L3Storage
{
    /*************** LLL Storage 2 *******************
     *
     *             D. Albertsson BUV23
     * "Completely Ridiculously Awesome Pallet-Handler"
     *     - a modestly advanced Storage Utility -
     *               ( aka C.R.A.P. )
     * 
     *                     8}
     *************************************************/

    public static void Main()
    {
        Storage.Run();
    }
}