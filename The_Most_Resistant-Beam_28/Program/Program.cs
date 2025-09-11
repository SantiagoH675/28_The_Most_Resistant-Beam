using System;

public class Exercise28
{
    public static void Main(string[] args)
    {
        string answer;
        string[] options = new[] { "s", "n" };

        do
        {
            Console.Write("Ingrese la viga: ");
            string beam = Console.ReadLine() ?? "";

            if (IsValid(beam))
            {
                if (SupportsWeight(beam))
                    Console.WriteLine("La viga soporta el peso!");
                else
                    Console.WriteLine("La viga NO soporta el peso!");
            }
            else
            {
                Console.WriteLine("La viga está mal construida!");
            }
            do
            {
                Console.Write("¿Desea continuar [S]í, [N]o?: ");
                answer = (Console.ReadLine() ?? "").Trim().ToLower();

                if (!Array.Exists(options, x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)))
                {
                    Console.WriteLine("Entrada no válida. Por favor ingrese 's' o 'n'.");
                }

            } while (!Array.Exists(options, x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

        } while (answer.Equals("s", StringComparison.CurrentCultureIgnoreCase));

        Console.WriteLine("Game Over");
    }
    public static bool IsValid(string beam)
    {
        if (string.IsNullOrEmpty(beam))
            return false;

        char baseChar = beam[0];
        if (baseChar != '%' && baseChar != '#' && baseChar != '&')
            return false;

        if (beam.Length == 1)
            return true;

        bool prevAsterisk = false;
        for (int i = 1; i < beam.Length; i++)
        {
            char c = beam[i];
            if (c != '=' && c != '*')
                return false;

            if (c == '*')
            {
                if (prevAsterisk) return false;
                prevAsterisk = true;
            }
            else
            {
                prevAsterisk = false;
            }
        }

        return true;
    }
    public static bool SupportsWeight(string beam)
    {
        int baseCapacity = beam[0] switch
        {
            '%' => 10,
            '#' => 30,
            '&' => 35,
            _ => 0
        };

        if (beam.Length == 1)
            return true;

        int totalWeight = 0;
        int segment = 0;

        for (int i = 1; i < beam.Length; i++)
        {
            char c = beam[i];
            if (c == '=')
            {
                segment++;
            }
            else
            {
                totalWeight += segment;
                segment = 0;
            }
        }
        totalWeight += segment;

        return baseCapacity >= totalWeight;
    }
}
