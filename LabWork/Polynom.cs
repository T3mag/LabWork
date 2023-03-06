using System;
using System.Text;

namespace labWork
{
	public class Polynom
	{
        public PolynomEllement First { get; set; }

        public void Insert(int coef, int deg1, int deg2, int deg3)
        {
            var addEllement = new PolynomEllement()
            {
                Index = coef,
                Degree1 = deg1,
                Degree2 = deg2,
                Degree3 = deg3
            };

            if (First == null)
            {
                addEllement.NextPolynomEllement = First;
                First = addEllement;
                return;
            }
            else
            {
                var elNow = First;
                var elNext = First;

                while (elNext != null) //elNow.NextPolynomEllement
                {
                    int s1 = int.Parse((elNext.Degree1).ToString() + (elNext.Degree2).ToString() + (elNext.Degree3).ToString());
                    int s2 = int.Parse((addEllement.Degree1).ToString() + (addEllement.Degree2).ToString() + (addEllement.Degree3).ToString());

                    if(elNext == First) 
                    {
                        if (s1 == s2)
                            return;
                        if (s1 > s2)
                            elNext = elNext.NextPolynomEllement;
                        if(s1 < s2)
                        {
                            var c = First;
                            First = addEllement;
                            First.NextPolynomEllement = c;
                            return;
                        }
                    }

                    else
                    {
                        if (s1 == s2)
                            return;

                        if(s1 > s2)
                        {
                            elNow = elNow.NextPolynomEllement;
                            elNext = elNext.NextPolynomEllement;
                        }

                        if(s1 < s2)
                        {
                            elNow.NextPolynomEllement = addEllement;
                            elNow.NextPolynomEllement.NextPolynomEllement = elNext;
                            return;
                        }
                    }
                }
                elNow.NextPolynomEllement = addEllement;
            }
        }

        public void Deleate(int deg1, int deg2, int deg3)
        {
            var elNow = First;
            var elNext = First;

            while(elNext != null)
            {
                if(elNext == First)
                {
                    if(elNext.Degree1 == deg1 && elNext.Degree2 == deg2 && elNext.Degree3 == deg3)
                    {
                        First = elNow.NextPolynomEllement;
                        return;
                    }
                    elNext = elNext.NextPolynomEllement;
                }
                else
                {
                    if(elNext.Degree1 == deg1 && elNext.Degree2 == deg2 && elNext.Degree3 == deg3)
                    {
                        elNow.NextPolynomEllement = elNext.NextPolynomEllement;
                        return;
                    }
                    elNow = elNow.NextPolynomEllement;
                    elNext = elNext.NextPolynomEllement;
                }
            }
            throw new ArgumentException("В полиноме нет такого числа!");
        }

        public int[] MinCoef()
        {
            var elNow = First;
            var mas = new int[3];
            var min = int.MaxValue;

            while (elNow != null)
            {
                if (elNow.Index < min)
                {
                    min = elNow.Index;
                    mas[0] = elNow.Degree1;
                    mas[1] = elNow.Degree2;
                    mas[2] = elNow.Degree3;
                }
                elNow = elNow.NextPolynomEllement;
            }

            return mas;
        }
        
        public override string ToString()
        {
            var sb = new StringBuilder();
            var el = First;

            while (el.NextPolynomEllement != null)
            {
                sb.Append($"{el.Index}*x^{el.Degree1}*y^{el.Degree2}*z^{el.Degree3} + ");
                el = el.NextPolynomEllement;
            }
            sb.Append($"{el.Index}*x^{el.Degree1}*y^{el.Degree2}*z^{el.Degree3}");

            return sb.ToString();
        }
    }
}