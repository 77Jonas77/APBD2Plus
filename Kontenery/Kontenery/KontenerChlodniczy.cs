using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Kontenery;

public class KontenerChlodniczy : Kontener
{
    private static string Rodzaj = "C";
    private List<Produkt> _produkty;     //ze typ?       
    private double _temp;
    
    public KontenerChlodniczy(double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, string serialNumber, double maxLadownosc, double temp) : base(masaLadunku, wysokosc, wagaWlasna, glebokosc, serialNumber, maxLadownosc)
    {
        _temp = temp;
        _produkty = new List<Produkt>();
    }

    public void ZaladujProdukt(Produkt produkt)
    {
        if (_produkty.Count != 0 && produkt.Typ!=_produkty.FirstOrDefault()!.Typ)
        {
            Console.WriteLine("Typ produktu niezgodny z dodanymi juz produktami!");
        }
        _produkty.Add(produkt);
        ZaladujKontener(masaLadunku + produkt.Waga);
    }
}