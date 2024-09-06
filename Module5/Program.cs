namespace Module5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var User = UserDataCollector();
            ShowUserData(User.Name, User.Surame, User.Age, User.HaveAPet, User.PetsCount, User.PetNames, User.FavColCount, User.FavCols);
        }

        static (string Name, string Surame, byte Age, bool HaveAPet, byte PetsCount, string[] PetNames, byte FavColCount, string[] FavCols) UserDataCollector()
        {
            Console.Write("What is your name: ");
            string Name = Console.ReadLine();

            Console.Write("What is your second name: ");
            string Surname = Console.ReadLine();

            Console.Write("How old are you: ");
            byte Age = NumChecker();

            Console.Write("Do you have a pet (y/n): ");
            bool HaveAPet = false;
            bool PetFlag = false;
            byte PetsCount = 0;
            string[] PetNames;
            do { // мне кажется, тут можно было сделать изящнее через swich/case, но если присваивать значения внутри такой конструкции, ругается, что HaveAPet не получится вернуть, потому что ей ничего не присвоено...
                string Symb = Console.ReadLine();
                if (Symb == "y")
                {
                    HaveAPet = true;
                    PetFlag = true;
                }
                else if (Symb == "n")
                {
                    HaveAPet = false;
                    PetFlag = true;
                }
                else
                {
                    Console.Write("Wrong symbol! Try again: ");
                }
            }
            while (!PetFlag);

            if (HaveAPet)
            {
                Console.Write("How many pets do you have: ");
                PetsCount = NumChecker();
                PetNames = new string[PetsCount];
                PetNames = PetNamesMeth(PetsCount);
            }
            else
            {
                PetNames = new string[1] { "none" };
            }

            Console.Write("How many favourite colors do you have: ");
            byte FavColCount = NumChecker();
            string[] FavCols;
            if (FavColCount > 0)
            {
                FavCols = new string[FavColCount];
                FavCols = FavColsMeth(FavColCount);
            }
            else
            {
                FavCols = new string[1];
                FavCols[0] = "none";
            }

            return (Name, Surname, Age, HaveAPet, PetsCount, PetNames, FavColCount, FavCols);
        }

        static string[] PetNamesMeth(byte PetsCount)
        {
            string[] PetNames = new string[PetsCount];
            for (int i = 0; i < PetsCount; i++)
            {
                Console.Write($"What is the name of your {i + 1} pet: ");
                PetNames[i] = Console.ReadLine();
            }
            return PetNames;
        }

        static string[] FavColsMeth(byte FavColCount) // этот метод полная копия предыдущего, что противореячит принципу DRY, но из задания я понял, что это должны быть разные методы
        {
            string[] FavCols = new string[FavColCount];
            for (int i = 0; i < FavColCount; i++)
            {
                Console.Write($"What is your {i + 1} favourite color: ");
                FavCols[i] = Console.ReadLine();
            }
            return FavCols;
        }

        static byte NumChecker()
        {
            byte num = 0;
            bool Check = byte.TryParse(Console.ReadLine(), out num);
            if (!Check || num <= 0) // ЧЗХ я должен иметь хотя бы один любимый цвет, ну если задача просит, то ладно
            {
                Console.Write("Wrong number format! Try again: ");
                num = NumChecker();
            }
            return num;
        }

        static void ShowUserData(string Name, string Surname, byte Age, bool HaveAPet, byte PetsCount, in string[] PetNames, byte FavColCount, in string[] FavCols)
        {
            Console.WriteLine($"So, your name is {Name} {Surname}");
            Console.WriteLine($"You are {Age} years old");
            if (HaveAPet)
            {
                Console.WriteLine($"You have {PetsCount} pets. Their names are:");
                foreach (string Pet in PetNames) Console.WriteLine(Pet);
            }
            else
            {
                Console.WriteLine("You have no pets");
            }

            if (FavColCount != 0)
            {
                Console.WriteLine($"You have {FavColCount} favourite colors. Their names are:");
                foreach (string Color in FavCols) Console.WriteLine(Color);
            }
            else
            {
                Console.WriteLine("You have no favourite colors"); // недостижимый по условиям задачи код, но мне очень хочется так сделать...
            }
        }
    }
}
