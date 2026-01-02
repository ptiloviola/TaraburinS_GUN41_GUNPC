class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Enter first number");

        if (!Int32.TryParse(Console.ReadLine(), out var a))
        {
            Console.WriteLine("Not a number!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Enter second number");

        if (!Int32.TryParse(Console.ReadLine(), out var b))
        {
            Console.WriteLine("Not a number!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Enter operator: &, | or ^");
        var oper = Console.ReadLine();

        if (oper.Length == 0 || oper.Length > 1)
        {
            Console.WriteLine("Wrong sign");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            return;
        }
        int res;
        switch (oper[0])
        {
            case '&':
                res = a & b;
                Console.WriteLine("Result of {0} & {1} = {2}(decimal), {3}(binary), {4}(hex)", a, b, Convert.ToString(res, 10), Convert.ToString(res, 2), Convert.ToString(res, 16));
                break;
            case '|':
                res = a | b;
                Console.WriteLine("Result of {0} | {1} = {2}(decimal), {3}(binary), {4}(hex)", a, b, Convert.ToString(res, 10), Convert.ToString(res, 2), Convert.ToString(res, 16));
                break;
            case '^':
                res = a ^ b;
                Console.WriteLine("Result of {0} ^ {1} = {2}(decimal), {3}(binary), {4}(hex)", a, b, Convert.ToString(res, 10), Convert.ToString(res, 2), Convert.ToString(res, 16));
                break;
            default:
                Console.WriteLine("wrong sign");
                break;
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

    }
}