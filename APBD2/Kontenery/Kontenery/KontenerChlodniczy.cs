using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Kontenery;

public class KontenerChlodniczy : Kontener
{
    private static string Rodzaj = "C";
    private List<Produkt> _produkty;     //ze typ?       
    private double _temp;
    
    public KontenerChlodniczy(double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, double maxLadownosc, double temp) : base(masaLadunku, wysokosc, wagaWlasna, glebokosc, Rodzaj, maxLadownosc)
    {
        _temp = temp;
        _produkty = new List<Produkt>();
    }

    public void ZaladujProdukt(Produkt produkt)
    {
        if (_produkty.Count != 0 && produkt.Typ!=_produkty.FirstOrDefault()!.Typ)
        {
            Console.WriteLine("Typ produktu niezgodny z dodanymi juz produktami!");
        }else if (produkt.Temperature < _temp)
        {
            Console.WriteLine("Temperatura w kontenerze wyzsza niz wymaga tego produkt!");
        }
        _produkty.Add(produkt);
        ZaladujKontener(masaLadunku + produkt.Waga);
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {nameof(_produkty)}: {_produkty}, {nameof(_temp)}: {_temp}";
    }
}