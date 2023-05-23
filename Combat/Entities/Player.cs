using System.Drawing;
using Combat.Methods.Melee;

namespace Combat;

public class Player : IEntity
{
    public Player()
    {
        Name = "Elysian";
        MeleeCombatManager = new MeleeCombatHandler(this);
    }

    public string Name { get; set; }
    public int Health { get; set; } = 10;
    public bool InCombat { get; set; }
    public IEntity CombatTarget { get; set; }
    public Weapon Weapon { get; set; } = new(4151, 70, 4, new CombatAnimations(1658, 1659, 1111), WeaponType.SWORD);
    public bool ResetCombat { get; set; } = false;
    public int X { get; set; } = 1;
    public int Y { get; set; } = 1;
    public MeleeCombatHandler MeleeCombatManager { get; set; }
}