namespace Module5
{
    internal class Program
    {
        static long Factorio(int x) // don't want to use decimal, long is enough 
        {
            if (x == 0) return 1; else return x * Factorio(x - 1);

            
        }
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            
            Console.WriteLine(Factorio(int.Parse(Console.ReadLine())));
        }
    }
}
