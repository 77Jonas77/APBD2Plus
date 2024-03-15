namespace Kontenery;

public abstract class Kontener
{
    private static int Id = 1;
    protected double masaLadunku;
    protected double wysokosc;
    protected double wagaWlasna;
    protected double glebokosc;
    protected string serialNumber;
    protected double maxLadownosc;

    protected Kontener(double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, string serialNumber, double maxLadownosc)
    {
        this.masaLadunku = masaLadunku;
        this.wysokosc = wysokosc;
        this.wagaWlasna = wagaWlasna;
        this.glebokosc = glebokosc;
        this.serialNumber = "KON-"+ serialNumber + "-" + Id;
        Id++;
        this.maxLadownosc = maxLadownosc;
    }
    
    protected virtual void OproznijLadunek()        //moze bd musiec zwracac      
    {
        masaLadunku = 0;
    }

    protected virtual void ZaladujKontener(double masaLadunku)
    {
        //to ma dodac wartosc do aktualnej czy zaladowac od konca?
        if (masaLadunku > maxLadownosc)
        {
            throw new OverfillException("Zbyt duzy ladunek! Kontener ma mniejsza ladownosc!");
        }
        this.masaLadunku = masaLadunku;
    }
}