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
    public WeaponType WeaponType { get; set; } = WeaponType.SWORD;
    public Weapon Weapon { get; set; } = new(4151, 70, 4, new CombatAnimations(1658, 1659, 1111), WeaponType.SWORD);
}