using Combat.Methods.Melee;

namespace Combat;

public class Player : IEntity
{
    public Player()
    {
        Name = "Elysian";
        CombatHandler = new CombatHandler
        {
            Attacker = this,
            CombatType = new MeleeCombat(this)
        };
    }

    public string Name { get; set; }
    public CombatHandler CombatHandler { get; set; }
    public int AttackSpeed { get; set; } = 4;
    public WeaponType WeaponType { get; set; } = WeaponType.SWORD;
}