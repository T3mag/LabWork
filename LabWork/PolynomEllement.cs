using System;
namespace labWork;
public class PolynomEllement
{
    public int Index { get; set; }
    public int Degree1 { get; set; }
    public int Degree2 { get; set; }
    public int Degree3 { get; set; }

    public PolynomEllement NextPolynomEllement { get; set; }
}