﻿namespace Combat.Methods.Melee;

public class MeleeCombat : ICombatMethod
{
    private readonly IEntity _attacker;

    public MeleeCombat(IEntity attacker)
    {
        _attacker = attacker;
        AttackDistance = _attacker.Weapon.Type == WeaponType.HALBERD ? 2 : 1;
    }

    public void Attack()
    {
        if (_attacker.CombatTarget == null)
            return;

        _attacker.CombatMethod.Tick++;
        if (_attacker.CombatMethod.Tick % _attacker.Weapon.Speed == 0)
        {
            ConsoleColorHandler.HandleConsoleColor(_attacker);
            Console.WriteLine($"{_attacker.Name} attacking {_attacker.CombatTarget.Name}");
            ConsoleColorHandler.ResetColor();

            var damage = _attacker.CombatMethod.CalculateDamage();
            _attacker.CombatTarget.CombatMethod.TakeDamage(damage.Damage);

            if (_attacker.CombatTarget.Health <= 0)
            {
                ConsoleColorHandler.Broadcast(1, $"{_attacker.Name} won over {_attacker.CombatTarget.Name}.");
                _attacker.CombatTarget.InCombat = false;
                _attacker.CombatTarget = null;
                _attacker.InCombat = false;
            }

            _attacker.CombatMethod.Tick = 0;
        }
    }

    public CombatHit CalculateDamage()
    {
        /* Combat formula etc */
        return new CombatHit
        {
            Damage = 5,
            Delay = 0,
            Type = DamageType.Damage
        };
    }

    public void TakeDamage(int damage)
    {
        _attacker.Health -= damage;
    }

    public int Tick { get; set; }
    public int AttackDistance { get; set; }

    public CombatHit[] HitCollection { get; set; }
}