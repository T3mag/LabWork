using System;
using System.IO;

using System.Text;

namespace labWork
{
	public class Polynom
	{
        public PolynomEllement First { get; set; }

        public Polynom(string file)
        {
            StreamReader sr = new StreamReader(file);
            var line = sr.ReadLine();
            
            while (line != null)
            {
                Insert(line[0] - '0', (int)line[1] - '0', (int)line[2] - '0', (int)line[3] - '0');
                line = sr.ReadLine();
            }
        }

        public Polynom()
        {
            
        }

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

        public void Derivate(int i)
        {
            if (i < 0 || i > 3)
                throw new ArgumentException("Нет такой переменной!");
            
            var ElNow = First;
            var ElNext = First;
            
            while (ElNext != null)
            {
                if (ElNow == ElNext)
                {
                    if (i == 1)
                    {
                        if (ElNext.Degree1 == 0)
                        {
                            ElNext = ElNext.NextPolynomEllement;
                            First = ElNext;
                        }
                        else
                        {
                            ElNext.Index = ElNext.Index * ElNext.Degree1;
                            ElNext.Degree1 = ElNext.Degree1 - 1;
                            ElNext = ElNext.NextPolynomEllement;
                        }
                    }
                    if (i == 2)
                    {
                        if (ElNext.Degree2 == 0)
                        {
                            ElNext = ElNext.NextPolynomEllement;
                            First = ElNext;
                        }
                        else
                        {
                            ElNext.Index = ElNext.Index * ElNext.Degree2;
                            ElNext.Degree2 = ElNext.Degree2 - 1;
                            ElNext = ElNext.NextPolynomEllement;
                        }
                    }
                    if (i == 3)
                    {
                        if (ElNext.Degree3 == 0)
                        {
                            ElNext = ElNext.NextPolynomEllement;
                            First = ElNext;
                        }
                        else
                        {
                            ElNext.Index = ElNext.Index * ElNext.Degree3;
                            ElNext.Degree3 = ElNext.Degree3 - 1;
                            ElNext = ElNext.NextPolynomEllement;
                        }
                    }
                }
                else
                {
                    if (i == 1)
                    {
                        if (ElNext.Degree1 == 0)
                        {
                            if (ElNext.NextPolynomEllement == null)
                            {
                                ElNow.NextPolynomEllement = null;
                                return;
                            }
                            else
                            {
                                ElNow.NextPolynomEllement = ElNext.NextPolynomEllement;
                            }
                        }
                        else
                        {
                            ElNext.Index = ElNext.Index * ElNext.Degree1;
                            ElNext.Degree1 = ElNext.Degree1 - 1;
                            ElNow = ElNext;
                            ElNext = ElNext.NextPolynomEllement;
                        }
                    }
                    if (i == 2)
                    {
                        if (ElNext.Degree2 == 0)
                        {
                            if (ElNext.NextPolynomEllement == null)
                            {
                                ElNow.NextPolynomEllement = null;
                                return;
                            }
                            else
                            {
                                ElNow.NextPolynomEllement = ElNext.NextPolynomEllement;
                            }
                        }
                            
                        else
                        {
                            ElNext.Index = ElNext.Index * ElNext.Degree2;
                            ElNext.Degree2 = ElNext.Degree2 - 1;
                            ElNow = ElNext;
                            ElNext = ElNext.NextPolynomEllement;
                        }
                    }
                    if (i == 3)
                    {
                        if (ElNext.Degree3 == 0)
                        {
                            if (ElNext.NextPolynomEllement == null)
                            {
                                ElNow.NextPolynomEllement = null;
                                return;
                            }
                            else
                            {
                                ElNow.NextPolynomEllement = ElNext.NextPolynomEllement;
                            }
                        }
                        else
                        {
                            ElNext.Index = ElNext.Index * ElNext.Degree3;
                            ElNext.Degree3 = ElNext.Degree3 - 1;
                            ElNow = ElNext;
                            ElNext = ElNext.NextPolynomEllement;
                        }
                    }
                }
                
            }
        }

        public void Add(Polynom polynom)
        {
            var elNowThis = this.First;
            var elNextThis = this.First;
            var elNowPol = polynom.First;
            
            while (true)
            {
                if (elNowPol == null)
                    break;
                
                if (elNextThis == null)
                {
                    elNextThis = elNowPol;
                    break;
                }
                
                int s1 = int.Parse((elNextThis.Degree1).ToString() + (elNextThis.Degree2).ToString() + (elNextThis.Degree3).ToString());
                int s2 = int.Parse((elNowPol.Degree1).ToString() + (elNowPol.Degree2).ToString() + (elNowPol.Degree3).ToString());

                if (elNowThis == elNextThis)
                {
                    if (s1 > s2)
                        elNextThis = elNowThis.NextPolynomEllement;
                    
                    if (s1 < s2)
                    {
                        elNowThis = this.First = elNowPol;
                        elNowThis.NextPolynomEllement = elNextThis;
                        elNowPol = elNowPol.NextPolynomEllement;
                    }

                    if (s1 == s2)
                        elNowPol = elNowPol.NextPolynomEllement;
                }
                else
                {
                    if (s1 > s2)
                    {
                        elNowThis = elNowThis.NextPolynomEllement;
                        elNextThis = elNextThis.NextPolynomEllement;
                    }
                        
                    if (s1 < s2)
                    {
                        elNowThis.NextPolynomEllement = elNowPol;
                        elNowThis.NextPolynomEllement.NextPolynomEllement = elNextThis;
                        elNextThis = elNextThis.NextPolynomEllement;
                        elNowPol = elNowPol.NextPolynomEllement;
                    }
                    if (s1 == s2)
                        elNowPol = elNowPol.NextPolynomEllement;
                }
            }
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
	// Привет!!!!!!!!!!
    }
}
