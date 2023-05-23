using Combat.Methods.Melee;

namespace Combat;

public interface IEntity
{
    public string Name { get; set; }
    public int Health { get; set; }
    public IEntity? CombatTarget { get; set; }
    public Weapon Weapon { get; set; }
    bool ResetCombat { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public MeleeCombatHandler MeleeCombatManager { get; set; }
}