using Combat.Methods.Melee;

namespace Combat;

public class CombatHandler
{
    private IEntity? _target;
    private int _tick;
    public IEntity? Attacker { get; set; }
    public ICombatMethod CombatType { get; set; }

    public void HandleEngage(IEntity target)
    {
        if (Attacker != null) _target = target;
        if (_target != null) _target.CombatHandler._target = Attacker;
        Attack();
    }

    public void HandleAttack()
    {
        _tick++;
        if (_target != null)
            if (_tick % Attacker?.AttackSpeed == 0)
                Attack();
    }

    private void Attack()
    {
        /* Can Attack? Valid distance, already in combat etc.. */
        var damage = CombatType.PerformDamage();
        ConsoleColorHandler.HandleConsoleColor(Attacker);
        Console.WriteLine($"+ {Attacker?.Name} Performing attack: WeaponType {Attacker.Weapon.Type}. Dealt {damage.Damage} damage of type {damage.Type} with {damage.Delay} ticks of delay.");
        ConsoleColorHandler.ResetColor();
    }
}