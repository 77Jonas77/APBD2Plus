using Kontenery;

public abstract class Kontener
{
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
        this.serialNumber = serialNumber;
        this.maxLadownosc = maxLadownosc;
    }
    
    protected void OproznijLadunek()        //moze bd musiec zwracac      
    {
        masaLadunku = 0;
    }

    protected void ZaladujKontener(double masaLadunku)
    {
        //to ma dodac wartosc do aktualnej czy zaladowac od konca?
        if (masaLadunku > maxLadownosc)
        {
            throw new OverfillException("Zbyt duzy ladunek! Kontener ma mniejsza ladownosc!");
        }
        this.masaLadunku = masaLadunku;
    }
}