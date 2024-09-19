using System.Reflection;

namespace _19._09
{
    internal class Program
    {

        delegate void GameMenuComponents();
        static void NewGame()
        {
            Console.WriteLine("new game");
        }
        static void LoadGame()
        {
            Console.WriteLine("load game");
        }
        static void Rules()
        {
            Console.WriteLine("list of rules");
        }
        static void AboutAuthor()
        {
            Console.WriteLine("About author");
        }
        static void ExitGame()
        {
            Console.WriteLine("exit game");
        }


        static void Main()
        {
            GameMenuComponents menu = NewGame;
            menu += LoadGame;
            menu += Rules;
            menu += AboutAuthor;
            menu += ExitGame;
            while (true)
            {
                Console.WriteLine("0 - новая игра\r\n1 - загрузить игру\r\n2 - правила\r\n3 - об авторе\r\n4 - выход");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice > 4 || choice<0)
                {
                    Console.WriteLine("error input");
                    continue;
                }
                MethodInfo mi = menu.GetInvocationList()[choice].Method;
                mi.Invoke(typeof(GameMenuComponents), null);
            }

        }
    }
}

