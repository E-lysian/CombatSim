namespace Combat;

public abstract class ConsoleColorHandler
{
    public static void HandleConsoleColor(IEntity? Attacker)
    {
        if (Attacker == null) throw new NullReferenceException("Attacker is null.");
        switch (Attacker)
        {
            case Player:
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            case NPC:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
        }
    }

    public static void Broadcast(int type, string message)
    {
        switch (type)
        {
            case 0:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                break;
            case 1:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                break;
        }

        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void ResetColor()
    {
        Console.ForegroundColor = ConsoleColor.White;
    }
}