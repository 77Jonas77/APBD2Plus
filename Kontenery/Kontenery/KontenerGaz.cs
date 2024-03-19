namespace Kontenery;

public class KontenerGaz : Kontener, IHazardNotifier
{
    private static string Rodzaj = "L";
    private int _cisnienie;

    public KontenerGaz(double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, double maxLadownosc, int cisnienie) : base(masaLadunku, wysokosc, wagaWlasna, glebokosc, Rodzaj, maxLadownosc)
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