using Combat.Methods.Melee;

namespace Combat;

public class Player : IEntity
{
    public Player()
    {
        Name = "Elysian";
    }

    public void Attack()
    {
        if (CombatTarget == null)
            return;
        
        CombatMethod.Tick++;
        if (CombatMethod.Tick % Weapon.Speed == 0)
        {
            var damage = CombatMethod.CalculateDamage();
            CombatTarget.CombatMethod.TakeDamage(damage.Damage);
            
            ConsoleColorHandler.HandleConsoleColor(this);
            Console.WriteLine($"{Name} attacking {CombatTarget.Name}");
            ConsoleColorHandler.ResetColor();
            CombatMethod.Tick = 0;
        }
    }

    public string Name { get; set; }
    public int Health { get; set; } = 15;
    public bool InCombat { get; set; }
    public IEntity CombatTarget { get; set; }
    public ICombatMethod CombatMethod { get; set; }
    public Weapon Weapon { get; set; } = new(4151, 70, 4, new CombatAnimations(1658, 1659, 1111), WeaponType.SWORD);
}