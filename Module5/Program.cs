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
            bool HaveAPet = Console.ReadLine() == "y" ? true : false;
            byte PetsCount;
            string[] PetNames;
            if (HaveAPet)
            {
                Console.Write("How many pets do you have: ");
                PetsCount = NumChecker();
                PetNames = new string[PetsCount];
                PetNames = PetNamesMeth(PetsCount);
            }
            else
            {
                PetsCount = 0;
                PetNames = new string[1];
                PetNames[0] = "none";
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

        static string[] FavColsMeth(byte FavColCount)
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
            if (!Check || num <= 0) // ЧЗХ я должен иметь хотя бы одного питомца или любимый цвет, ну если задача просит, то ладно
            {
                Console.WriteLine("Wrong number format! Try again");
                num = NumChecker(); /* вот тут не понял, но почему-то, если просто в этом блоке рекурсивно вызывать NumChecker(), не в переменную, как сейчас,...
						... и воспроизвести неправильный ввод, то программа, как и должна, попросит ввести повторно, примет верное число больше нуля, и, казалось бы, вернёт его,...
						... но почему-то после возврата правильного num опять перескочит на рекурсивный вызов и вернёт 0 вместо правильного числа, и только после этого выйдет*/
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
