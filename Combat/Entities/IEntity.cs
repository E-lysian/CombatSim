using Combat.Methods.Melee;

namespace Combat;

public interface IEntity
{
    public string Name { get; set; }
    public int Health { get; set; }
    public bool InCombat { get; set; }
    public IEntity CombatTarget { get; set; }
    public ICombatMethod CombatMethod { get; set; }
    public Weapon Weapon { get; set; }
}