
using ECMLab2T;

while (true)
{
    Console.WriteLine("\rPress [C] to run client or press [S] to run server");
    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.C)
    {
        Console.WriteLine("\rRunning client...");
        Client.Run();
        break;
    }
    if (key.Key == ConsoleKey.S)
    {
        Console.WriteLine("\rRunning server...");
        await Server.Run();
        break;
    }
}