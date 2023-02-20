using System;
using System.Collections.Generic;
using System.Linq;

interface IFigura
{
    double Obwod { get; }
    double Pole { get; }
    void Powieksz(int multi);
    void Pomniejsz(int div);
}

class Kwadrat : IFigura
{
    private double bokKwadratu;

    public Kwadrat(double bok)
    {
        this.bokKwadratu = bok;
    }

    public double Obwod => 4 * bokKwadratu;
    public double Pole => bokKwadratu * bokKwadratu;

    public void Powieksz(int multi)
    {
        bokKwadratu *= multi;
    }

    public void Pomniejsz(int div)
    {
        bokKwadratu /= div;
    }

    public override string ToString()
    {
        return $"Kwadrat: długość boku {bokKwadratu}";
    }
}

class Prostokat : IFigura
{
    private double pierwszyBok, drugiBok;

    public Prostokat(double a, double b)
    {
        this.pierwszyBok = a;
        this.drugiBok = b;
    }

    public double Obwod => 2 * (pierwszyBok + drugiBok);
    public double Pole => pierwszyBok * drugiBok;

    public void Powieksz(int multi)
    {
        pierwszyBok *= multi;
        drugiBok *= multi;
    }

    public void Pomniejsz(int div)
    {
        pierwszyBok /= div;
        drugiBok /= div;
    }

    public override string ToString()
    {
        return $"Prostokąt: długość boków {pierwszyBok} i {drugiBok}";
    }
}

class Kolo : IFigura
{
    private double promien;

    public Kolo(double r)
    {
        this.promien = r;
    }

    public double Obwod => 2 * Math.PI * promien;
    public double Pole => Math.PI * promien * promien;

    public void Powieksz(int multi)
    {
        promien *= multi;
    }

    public void Pomniejsz(int div)
    {
        promien /= div;
    }

    public override string ToString()
    {
        return $"Koło: promień {promien}";
    }
}

abstract class FiguraFabryka
{
    public abstract IFigura Utworz();
}

class KwadratFabryka : FiguraFabryka
{
    public override IFigura Utworz()
    {
        return new Kwadrat(new Random().Next(1, 10));
    }
}

class ProstokatFabryka : FiguraFabryka
{
    public override IFigura Utworz()
    {
        return new Prostokat(new Random().Next(1, 10), new Random().Next(1, 10));
    }
}

class KoloFabryka : FiguraFabryka
{
    public override IFigura Utworz()
    {
        return new Kolo(new Random().Next(1, 10));
    }
}

class Figura
{
    private static Dictionary<string, FiguraFabryka> fabryka = new Dictionary<string, FiguraFabryka>
    {
    { "Kwadrat", new KwadratFabryka() },
    { "Prostokat", new ProstokatFabryka() },
    { "Kolo", new KoloFabryka() }
    };

    private static List<IFigura> listaFigur = new List<IFigura>();

    public static void DodajFigure(string nazwa)
    {
        listaFigur.Add(fabryka[nazwa].Utworz());
    }

    public static void WyswietlListeFigur()
    {
        for (int i = 0; i < listaFigur.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {listaFigur[i]}");
        }
    }

    public static void WyswietlFigure(int index)
    {
        Console.WriteLine(listaFigur[index - 1]);
    }

    public static void UsunFigure(int index)
    {
        listaFigur.RemoveAt(index - 1);
    }

    public static void PowiekszFigure(int index, int multi)
    {
        listaFigur[index - 1].Powieksz(multi);
    }

    public static void PomniejszFigure(int index, int div)
    {
        listaFigur[index - 1].Pomniejsz(div);
    }
}

class Projekt
{
    static void Main(string[] args)
    {
        // Losowo dodaj listaFigur do listy
        Figura.DodajFigure("Kwadrat");
        Figura.DodajFigure("Prostokat");
        Figura.DodajFigure("Kolo");
        Figura.DodajFigure("Kwadrat");
        // Pętla menu
        bool zakonczono = false;
        while (!zakonczono)
        {
            Console.WriteLine("");
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Wyswietl listę figur");
            Console.WriteLine("2. Wyswietl wybraną figurę");
            Console.WriteLine("3. Usun wybraną figurę");
            Console.WriteLine("4. Dodaj nową figurę");
            Console.WriteLine("5. Powieksz wybraną figurę");
            Console.WriteLine("6. Pomniejsz wybraną figurę");
            Console.WriteLine("7. Zakończ");
            int wybor = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            switch (wybor)
            {
                case 1:
                    Figura.WyswietlListeFigur();
                    break;
                case 2:
                    Console.Write("Podaj indeks figury: ");
                    int index = int.Parse(Console.ReadLine());
                    Figura.WyswietlFigure(index);
                    break;
                case 3:
                    Console.Write("Podaj indeks figury do usunięcia: ");
                    index = int.Parse(Console.ReadLine());
                    Figura.UsunFigure(index);
                    break;
                case 4:
                    Console.Write("Podaj nazwę figury do dodania (Kwadrat, Prostokat, Kolo): ");
                    string nazwa = Console.ReadLine();
                    Figura.DodajFigure(nazwa);
                    break;
                case 5:
                    Console.Write("Podaj indeks figury do powiększenia: ");
                    index = int.Parse(Console.ReadLine());
                    Console.Write("Podaj o ile chcesz powiększyć figurę: ");
                    int multi = int.Parse(Console.ReadLine());
                    Figura.PowiekszFigure(index, multi);
                    break;
                case 6:
                    Console.Write("Podaj indeks figury do pomniejszenia: ");
                    index = int.Parse(Console.ReadLine());
                    Console.Write("Podaj o ile chcesz pomniejszyć figurę: ");
                    int div = int.Parse(Console.ReadLine());
                    Figura.PomniejszFigure(index, div);
                    break;
                case 7:
                    zakonczono = true;
                    break;
            }
        }
    }
}

