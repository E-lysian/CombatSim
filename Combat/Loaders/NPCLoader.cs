namespace Combat;

public class NPCLoader
{
    public static List<IEntity> Entities { get; set; } = new();

    public static void Load()
    {
        Entities.Add(new Player());
        Entities.Add(new NPC());
    }
}