using System;

public class Exercise28
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the beam: ");
        string beam = Console.ReadLine();

        if (IsValid(beam))
        {
            if (SupportsWeight(beam))
            {
                Console.WriteLine("The beam supports the weight!");
            }
            else
            {
                Console.WriteLine("The beam does not support the weight!");
            }
        }
        else
        {
            Console.WriteLine("The beam is poorly constructed");
        }
    }

    public static bool IsValid(string beam)
    {
        if (string.IsNullOrEmpty(beam)) return false;

        char baseChar = beam[0];
        if (!(baseChar == '#' || baseChar == '%' || baseChar == '&'))
        {
            return false;
        }

        int n = beam.Length;
        int consecutiveStars = 0;

        for (int i = 1; i < n; i++)
        {
            char piece = beam[i];

            if (!(piece == '=' || piece == '*'))
            {
                return false;
            }

            if (piece == '*')
            {
                consecutiveStars++;
            }
            else
            {
                consecutiveStars = 0;
            }

            if (consecutiveStars == 2)
            {
                return false;
            }
        }

        if (consecutiveStars == n)
        {
            return false;
        }

        return true;
    }

    public static bool SupportsWeight(string beam)
    {
        if (string.IsNullOrEmpty(beam)) return false;

        char baseChar = beam[0];

        int n = beam.Length;
        int totalWeight = 0;
        int segmentWeight = 0;

        for (int i = 1; i < n; i++)
        {
            char piece = beam[i];

            if (piece == '=')
            {
                segmentWeight++;
            }
            else
            {
                totalWeight += segmentWeight * 3;
                segmentWeight = 0;
            }
        }

        totalWeight += segmentWeight;

        int baseWeight = 0;
        switch (baseChar)
        {
            case '%':
                baseWeight = 10;
                break;

            case '&':
                baseWeight = 30;
                break;

            case '#':
                baseWeight = 90;
                break;
        }

        return baseWeight >= totalWeight;
    }
}