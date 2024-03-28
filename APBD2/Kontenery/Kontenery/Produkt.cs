namespace Kontenery;

public class Produkt
{
    public string Name { get; set; }
    public string Typ { get; set; }
    public double Waga { get; set; }
    public double Temperature { get; set; }

    public Produkt(string name, double temperature, string typ, double waga)
    {
        Name = name;
        Temperature = temperature;
        Typ = typ;
        Waga = waga;
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Typ)}: {Typ}, {nameof(Waga)}: {Waga}, {nameof(Temperature)}: {Temperature}";
    }
}