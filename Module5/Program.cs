namespace Module5
{
    internal class Program
    {
        static long Power(int x, byte pow)
        {
            if (pow == 0)
            {
                return 1;
            }
            else
            {
                if (pow == 1)
                {
                    return x;
                }
                else
                {
                    return x * Power(x, --pow);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter number and then power for it: ");
            
            Console.WriteLine(Power(int.Parse(Console.ReadLine()), byte.Parse(Console.ReadLine())));
        }
    }
}
