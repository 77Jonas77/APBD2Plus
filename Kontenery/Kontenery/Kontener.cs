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

    public double MasaLadunku => masaLadunku;

    public double WagaWlasna => wagaWlasna;

    public string SerialNumber
    {
        get => serialNumber;
        set => serialNumber = value ?? throw new ArgumentNullException(nameof(value));
    }

    public override string ToString()
    {
        return $"{nameof(masaLadunku)}: {masaLadunku}, {nameof(wysokosc)}: {wysokosc}, {nameof(wagaWlasna)}: {wagaWlasna}, {nameof(glebokosc)}: {glebokosc}, {nameof(serialNumber)}: {serialNumber}, {nameof(maxLadownosc)}: {maxLadownosc}, {nameof(MasaLadunku)}: {MasaLadunku}, {nameof(WagaWlasna)}: {WagaWlasna}, {nameof(SerialNumber)}: {SerialNumber}";
    }
    //jak zmienic statek? z poziomu kontenera czy statku?
}