namespace Kontenery;

public class MainClass
{
    public static void Main(string[] args)
    {
        Kontener k = new KontenerGaz(2,3,4,5,300,30);
        Console.WriteLine(k.SerialNumber);
        Kontener z = new KontenerGaz(2, 3, 4, 3,1,4);
        Console.WriteLine(z);
        //gl hf
    }
}