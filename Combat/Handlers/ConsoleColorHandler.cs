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

    public static void ResetColor()
    {
        Console.ForegroundColor = ConsoleColor.White;
    }
}