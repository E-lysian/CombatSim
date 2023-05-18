namespace Combat;

public class Player : IEntity
{
    public Player()
    {
        Name = "Elysian";
        CombatHandler = new CombatHandler
        {
            AttackSpeed = 4,
            Attacker = this
        };
    }

    public string Name { get; set; }
    public CombatHandler CombatHandler { get; set; }
}