namespace labWork;

public class Program
{
    public static void Main()
    {
        var pol1 = new Polynom("Polynom.txt");
        var pol = new Polynom();
        pol.Insert(1, 1, 3, 2);
        pol.Insert(2, 1, 2, 1);
        
        Console.WriteLine(pol);
        Console.WriteLine(pol1);
        
        pol.Add(pol1);
        
         Console.WriteLine(pol);

    }
}