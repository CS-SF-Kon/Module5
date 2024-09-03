namespace Module5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string Name, string[] Dishes) User;
            string[] Count = new[] {"first", "second", "third", "fourth", "fifth" };

            Console.Write("What is your name: ");
            User.Name = Console.ReadLine();
            
            User.Dishes = new string[5];
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter your {Count[i]} favourite dish: ");
                User.Dishes[i] = Console.ReadLine();
            }

        }
    }
}
