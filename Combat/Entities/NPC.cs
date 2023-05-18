using Combat.Methods.Melee;

namespace Combat;

public class NPC : IEntity
{
    public NPC()
    {
        Name = "Goblin";
        CombatHandler = new CombatHandler
        {
            Attacker = this,
            CombatType = new MeleeCombat(this)
        };
    }

    public string Name { get; set; }
    public CombatHandler CombatHandler { get; set; }
    public int AttackSpeed { get; set; } = 5;
    public WeaponType WeaponType { get; set; } = WeaponType.HAND;
}