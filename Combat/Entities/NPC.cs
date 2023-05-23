using System.Drawing;
using Combat.Methods.Melee;

namespace Combat;

public class NPC : IEntity
{
    public NPC()
    {
        Name = "Goblin";
        MeleeCombatManager = new MeleeCombatHandler(this);
    }

    public string Name { get; set; }
    public int Health { get; set; } = 10;
    public bool InCombat { get; set; }
    public IEntity CombatTarget { get; set; }
    public Weapon Weapon { get; set; } = new(0, 0, 4, new CombatAnimations(0, 0, 0), WeaponType.HAND);
    public bool ResetCombat { get; set; } = false;
    public int X { get; set; } = 1;
    public int Y { get; set; } = 5;
    public MeleeCombatHandler MeleeCombatManager { get; set; }

}