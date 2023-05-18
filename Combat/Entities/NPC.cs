using Combat.Methods.Melee;

namespace Combat;

public class NPC : IEntity
{
    public NPC()
    {
        Name = "Goblin";
    }

    public string Name { get; set; }
    public int Health { get; set; } = 15;
    public bool InCombat { get; set; }
    public IEntity CombatTarget { get; set; }
    public ICombatMethod CombatMethod { get; set; }
    public Weapon Weapon { get; set; } = new(0, 0, 5, new CombatAnimations(0, 0, 0), WeaponType.HAND);
}