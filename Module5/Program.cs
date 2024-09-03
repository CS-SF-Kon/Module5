namespace Module5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string Name, string[] Colors) User;
            //string[] Count = new[] {"first", "second", "third", "fourth", "fifth" };

            Console.Write("What is your name: ");
            User.Name = Console.ReadLine();
            
            static string[] ShowColor()
            {
                string[] Col = new string[3];
                string[] Count = new[] { "first", "second", "third" };
                for (int i = 0; i<3; i++)
                {
                    Console.Write($"Enter your {Count[i]} favourite color: ");
                    Col[i] = Console.ReadLine();
                }
                return Col;
            }
            
            User.Colors = new string[3];
            User.Colors = ShowColor();


            Console.WriteLine(User.Name);
            foreach (var color  in User.Colors) Console.WriteLine(color);


            //User.Dishes = new string[5];
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write($"Enter your {Count[i]} favourite dish: ");
            //    User.Dishes[i] = Console.ReadLine();
            //}

        }
    }
}
