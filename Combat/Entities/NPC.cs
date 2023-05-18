namespace Combat;

public class NPC : IEntity
{
    public NPC()
    {
        Name = "Goblin";
        CombatHandler = new CombatHandler
        {
            AttackSpeed = 10,
            Attacker = this
        };
    }

    public string Name { get; set; }
    public CombatHandler CombatHandler { get; set; }
}