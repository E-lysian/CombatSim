namespace Combat;

public class NPCLoader
{
    public static List<IEntity> Npcs { get; set; } = new();

    public static void Load()
    {
        Npcs.Add(new NPC());
    }
}