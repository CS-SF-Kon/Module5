namespace Module5
{
    internal class Program
    {
        static void Echo(string phrase, byte depth)
        {
            string modif = phrase;
            if (modif.Length > 2)
            {
                modif = modif.Remove(0, 2);
                Console.BackgroundColor = (ConsoleColor)depth;
                Console.WriteLine("..." + modif);
                if (depth > 1) Echo(modif, (byte) (depth - 1));
            }

        }
        static void Main(string[] args)
        {
            Console.Write("Print something: ");
            string text = Console.ReadLine();
            Console.Write("Print the depth of echo: ");
            byte depth = byte.Parse(Console.ReadLine());
            
            Echo(text, depth);

        }
    }
}
