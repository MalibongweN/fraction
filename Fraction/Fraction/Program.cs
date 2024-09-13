using System;

public class Fraction
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }

        Numerator = numerator;
        Denominator = denominator;
        Simplify();
    }

    //+ operator
    public static Fraction operator +(Fraction a, Fraction b)
    {
        int numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        int denominator = a.Denominator * b.Denominator;
        return new Fraction(numerator, denominator);
    }

    //- operator
    public static Fraction operator -(Fraction a, Fraction b)
    {
        int numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
        int denominator = a.Denominator * b.Denominator;
        return new Fraction(numerator, denominator);
    }

    //* operator
    public static Fraction operator *(Fraction a, Fraction b)
    {
        return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
    }

    //division 
    public static Fraction operator /(Fraction a, Fraction b)
    {
        return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
    }

    //++ operator
    public static Fraction operator ++(Fraction a)
    {
        return a + new Fraction(1, 1);
    }

    //-- operator
    public static Fraction operator --(Fraction a)
    {
        return a - new Fraction(1, 1);
    }

    //== operator
    public static bool operator ==(Fraction a, Fraction b)
    {
        return a.Numerator * b.Denominator == b.Numerator * a.Denominator;
    }

    //!= operator
    public static bool operator !=(Fraction a, Fraction b)
    {
        return !(a == b);
    }

    //< operator
    public static bool operator <(Fraction a, Fraction b)
    {
        return a.Numerator * b.Denominator < b.Numerator * a.Denominator;
    }

    //> operator
    public static bool operator >(Fraction a, Fraction b)
    {
        return a.Numerator * b.Denominator > b.Numerator * a.Denominator;
    }

    
    private void Simplify()
    {
        int gcd = GCD(Math.Abs(Numerator), Math.Abs(Denominator));
        Numerator /= gcd;
        Denominator /= gcd;

        if (Denominator < 0) 
        {
            Numerator = -Numerator;
            Denominator = -Denominator;
        }
    }

    //greatest common divisor
    private static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }

    
    public override bool Equals(object obj)
    {
        if (obj is Fraction fraction)
        {
            return this == fraction;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Numerator.GetHashCode() ^ Denominator.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nFraction Calculator");
            Console.WriteLine("1. Add two fractions");
            Console.WriteLine("2. Subtract two fractions");
            Console.WriteLine("3. Multiply two fractions");
            Console.WriteLine("4. Divide two fractions");
            Console.WriteLine("5. Compare two fractions");
            Console.WriteLine("6. Increment a fraction");
            Console.WriteLine("7. Decrement a fraction");
            Console.WriteLine("8. Exit");
            Console.Write("Select an option (1-8): ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    PerformOperation('+');
                    break;
                case 2:
                    PerformOperation('-');
                    break;
                case 3:
                    PerformOperation('*');
                    break;
                case 4:
                    PerformOperation('/');
                    break;
                case 5:
                    CompareFractions();
                    break;
                case 6:
                    IncrementFraction();
                    break;
                case 7:
                    DecrementFraction();
                    break;
                case 8:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

   
    static Fraction GetFractionInput(string prompt)
    {
        Console.WriteLine(prompt);
        Console.Write("Enter numerator: ");
        int numerator = int.Parse(Console.ReadLine());
        Console.Write("Enter denominator: ");
        int denominator = int.Parse(Console.ReadLine());
        return new Fraction(numerator, denominator);
    }


    static void PerformOperation(char operation)
    {
        Fraction a = GetFractionInput("Enter the first fraction:");
        Fraction b = GetFractionInput("Enter the second fraction:");
        Fraction result = null;

        switch (operation)
        {
            case '+':
                result = a + b;
                Console.WriteLine($"Result: {a} + {b} = {result}");
                break;
            case '-':
                result = a - b;
                Console.WriteLine($"Result: {a} - {b} = {result}");
                break;
            case '*':
                result = a * b;
                Console.WriteLine($"Result: {a} * {b} = {result}");
                break;
            case '/':
                result = a / b;
                Console.WriteLine($"Result: {a} / {b} = {result}");
                break;
        }
    }

    
    static void CompareFractions()
    {
        Fraction a = GetFractionInput("Enter the first fraction:");
        Fraction b = GetFractionInput("Enter the second fraction:");

        if (a == b)
        {
            Console.WriteLine($"{a} is equal to {b}");
        }
        else if (a > b)
        {
            Console.WriteLine($"{a} is greater than {b}");
        }
        else
        {
            Console.WriteLine($"{a} is less than {b}");
        }
    }

   
    static void IncrementFraction()
    {
        Fraction a = GetFractionInput("Enter the fraction to increment:");
        Fraction result = ++a;
        Console.WriteLine($"Incremented result: {result}");
    }


    static void DecrementFraction()
    {
        Fraction a = GetFractionInput("Enter the fraction to decrement:");
        Fraction result = --a;
        Console.WriteLine($"Decremented result: {result}");
    }
}
