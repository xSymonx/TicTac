namespace Lista_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj pierwsza liczbe: ");
            float liczba1 = float.Parse(Console.ReadLine());
            Console.Write("Podaj druga liczbe: ");
            float liczba2 = float.Parse(Console.ReadLine());
            Console.WriteLine("Roznica dwoch wprowadzonych liczb: " + Math.Round(liczba1 - liczba2, 4));
            Console.WriteLine("Iloczyn dwoch wprowadzonych liczb: " + Math.Round(liczba1 * liczba2, 4));
            Console.WriteLine("Iloraz dwoch wprowadzonych liczb: " + Math.Round(liczba1 / liczba2, 4));
        }
    }
}