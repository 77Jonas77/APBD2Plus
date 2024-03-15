namespace Kontenery;

public class KontenerPlyny : Kontener, IHazardNotifier
{
    private static string Rodzaj = "L";
    private double _niebezpLadunek;
    private double _zwyklyLadunek;

    public KontenerPlyny(double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, double maxLadownosc, double niebezpLadunek, double zwyklyLadunek) : base(masaLadunku, wysokosc, wagaWlasna, glebokosc, Rodzaj, maxLadownosc)
    {
        _niebezpLadunek = niebezpLadunek;
        _zwyklyLadunek = zwyklyLadunek;
    }


    protected override void ZaladujKontener(double masaLadunku)
    {
        if (_niebezpLadunek > 0 && (maxLadownosc/2)<masaLadunku)
        { 
            wyslijKomunikat("Niebezpieczna operacja - (>50% pojemnosci) przewazac niebezpieczny ladunek!!!",serialNumber);
        }else if (masaLadunku > (0.9 * maxLadownosc))
        {
            wyslijKomunikat("Niebezpieczna operacja - (>90% pojemnosci)!!!",serialNumber);
        }
        base.ZaladujKontener(masaLadunku);
    }

    public void wyslijKomunikat(string wiadomosc, string serialNr)
    {
        Console.WriteLine(serialNr  + ": " + wiadomosc);
    }
}