namespace Kontenery;

public class KontenerGaz : Kontener, IHazardNotifier
{
    private int _cisnienie;


    public KontenerGaz(double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, string serialNumber, double maxLadownosc, int cisnienie) : base(masaLadunku, wysokosc, wagaWlasna, glebokosc, serialNumber, maxLadownosc)
    {
        _cisnienie = cisnienie;
    }

    protected override void OproznijLadunek()
    {
        base.masaLadunku = 0.05 * masaLadunku;
    }

    public void wyslijKomunikat(string wiadomosc, string serialNr)
    {
        Console.WriteLine(serialNr  + ": " + wiadomosc);
    }
    
}