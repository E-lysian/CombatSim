namespace Combat.Handlers.Combat;

public class CombatFactory
{
    public void Attack(IEntity attacker)
    {
        attacker.CombatMethod.Tick++;

        if (attacker.CombatMethod.Tick % attacker.Weapon.Speed == 0)
        {
            if (attacker.CombatTarget.InCombat)
            {
                ConsoleColorHandler.HandleConsoleColor(attacker);
                Console.WriteLine($"+ {attacker.Name} Attacking {attacker.CombatTarget.Name}.");
                ConsoleColorHandler.ResetColor();

                var damage = attacker.CombatMethod.CalculateDamage();
                attacker.CombatTarget.CombatMethod.TakeDamage(damage.Damage);
                if (attacker.CombatTarget.Health <= 0)
                {
                    attacker.CombatTarget.InCombat = false;
                    ConsoleColorHandler.Broadcast(0, $"{attacker.CombatTarget.Name} died.");
                    Console.WriteLine($"CombatTarget [{attacker.CombatTarget.Name}] no longer in combat with [{attacker.Name}]");
                }

                attacker.CombatMethod.Tick = 0;
            }
            else
            {
                attacker.InCombat = false;
                Console.WriteLine($"Attacker [{attacker.Name}] no longer in combat");
            }
        }
    }
}