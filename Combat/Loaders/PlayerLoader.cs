using Combat;

public class PlayerLoader
{
    public static List<IEntity> Players { get; set; } = new();

    public static void Load()
    {
        Players.Add(new Player());
    }
}