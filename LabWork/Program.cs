namespace labWork;

public class Program
{
    public static void Main()
    {
        var pol = new Polynom();

        pol.Insert(1, 4, 3, 2);
        pol.Insert(2, 3, 2, 1);
        pol.Insert(5, 7, 1, 1);
        pol.Insert(8, 3, 0, 1);
        pol.Insert(2, 3, 0, 1);

        pol.Deleate(3,2,1);

        var mas = pol.MinCoef();
        for (int i = 0; i < mas.Length; i++)
        {
            Console.Write(mas[i]+",");
        }
        Console.WriteLine();
        
        Console.WriteLine(pol);

    }
}