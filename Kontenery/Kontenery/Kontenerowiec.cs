using System.Net.NetworkInformation;
using System.Security.AccessControl;

namespace Kontenery;

public class Kontenerowiec
{
    private List<Kontener> _kontenery;
    private double maxPredkosc;
    private int maxPojemnoscLicz;
    private int maxPojemnoscWaga;
    private double wagaLadunku;

    public Kontenerowiec(double maxPredkosc, int maxPojemnoscLicz, int maxPojemnoscWaga)
    {
        this.maxPredkosc = maxPredkosc;
        this.maxPojemnoscLicz = maxPojemnoscLicz;
        this.maxPojemnoscWaga = maxPojemnoscWaga;
        this.wagaLadunku = 0;
    }

    public int DodajKontener(Kontener kontener)
    {
        if (_kontenery.Count + 1 > maxPojemnoscLicz)
        {
            Console.WriteLine("Niestety kontenerowiec przekroczy dopuszczalna ilosc kontenerow");
            return 1;
        }

        if (wagaLadunku + kontener.MasaLadunku + kontener.WagaWlasna > maxPojemnoscWaga)
        {
            Console.WriteLine("Niestety kontenerowiec przekroczy dopuszczalna wage");
            return 1;
        }
        
        _kontenery.Add(kontener);
        wagaLadunku += kontener.MasaLadunku + kontener.WagaWlasna;

        return 0;
    }

    //troche nietypowe ale dziala dla naszego przykladu
    public void DodajKontenery(List<Kontener> kontenery) 
    {
        foreach (var kontener in kontenery)
        {
            if (DodajKontener(kontener) == 1)
                break;
        }
    }

    public void UsunKontener(Kontener kontener)
    {
        if (_kontenery.Contains(kontener))
        {
            _kontenery.Remove(kontener);
            wagaLadunku -= (kontener.MasaLadunku + kontener.WagaWlasna);
        }
        else
        {
            Console.WriteLine("Nie ma takiego kontenera na statku!");
        }
    }
    
    //nwm czy o to chodzilo?
    public void ZastapKontener(Kontener kontenerZal, Kontener kontenerDoZaladowania)
    {
        //bool czyz = false;
        _kontenery.Remove(kontenerZal);
        kontenerDoZaladowania.SerialNumber = kontenerDoZaladowania.SerialNumber;
        _kontenery.Add(kontenerDoZaladowania);
    }

    public void WyswietlInformacje()
    {
        Console.WriteLine($"m_pred: {maxPredkosc} m_liczbaKont: {maxPojemnoscLicz} m_pojWaga: {maxPojemnoscWaga} aktualna_waga: {wagaLadunku} \nKontenery: ");
        foreach (var kontener in _kontenery)
        {
            Console.Write($"{kontener.SerialNumber} ");
        }
    }

    public void PrzeniesKontener(Kontener kontener, Kontenerowiec kontenerowiec)
    {
        _kontenery.Remove(kontener);
        kontenerowiec._kontenery.Add(kontener);
    } 
}