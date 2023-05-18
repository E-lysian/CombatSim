using Combat.Methods.Melee;

namespace Combat;

public class NPC : IEntity
{
    public NPC()
    {
        Name = "Goblin";
    }

    public void Attack()
    {
        if (CombatTarget == null)
            return;
        
        CombatMethod.Tick++;
        if (CombatMethod.Tick % Weapon.Speed == 0)
        {
            ConsoleColorHandler.HandleConsoleColor(this);
            Console.WriteLine($"{Name} attacking {CombatTarget.Name}");
            ConsoleColorHandler.ResetColor();

            var damage = CombatMethod.CalculateDamage();
            CombatTarget.CombatMethod.TakeDamage(damage.Damage);
            CombatMethod.Tick = 0;
        }
    }

    public string Name { get; set; }
    public int Health { get; set; } = 15;
    public bool InCombat { get; set; }
    public IEntity CombatTarget { get; set; }
    public ICombatMethod CombatMethod { get; set; }
    public Weapon Weapon { get; set; } = new(0, 0, 4, new CombatAnimations(0, 0, 0), WeaponType.HAND);
}