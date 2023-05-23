using Combat.Methods.Melee;

namespace Combat;

public class MeleeCombatHandler : ICombatManager
{
    private readonly IEntity _attacker;
    private bool _initiated;

    public bool InCombat { get; set; }
    public IEntity Target { get; set; }
    public bool IsInitiator { get; set; }
    public int Tick { get; set; }

    public MeleeCombatHandler(IEntity attacker)
    {
        _attacker = attacker;
    }

    public void Initiate()
    {
        if (!_initiated)
        {
            InCombat = true;
            _initiated = true;
            ConsoleColorHandler.Broadcast(2, $"{_attacker.Name} Initiated combat with {Target.Name}!");

            if (IsInitiator)
            {
                Tick = _attacker.Weapon.Speed - 1;
            }
        }
    }

    public void Attack()
    {
        Initiate();

        if (InCombat)
        {
            Tick++;

            if (Tick % _attacker.Weapon.Speed == 0)
            {
                Console.WriteLine($"{_attacker.Name} Attacking!");

                var damage = CalculateDamage();
                Target.MeleeCombatManager.TakeDamage(damage.Damage);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        _attacker.Health -= damage;
        ConsoleColorHandler.Broadcast(0, $"[{_attacker.Health}] {_attacker.Name} Took {damage} Damage!");
    }

    public void CheckWonBattle()
    {
        if (InCombat && Target.Health <= 0)
        {
            ConsoleColorHandler.Broadcast(1, $"{_attacker.Name} Won over {Target.Name}.");
            InCombat = false;
        }
    }

    public void CheckLostBattle()
    {
        if (InCombat && _attacker.Health <= 0)
        {
            ConsoleColorHandler.Broadcast(2, $"{_attacker.Name} Lost to {Target.Name}.");
            InCombat = false;
        }
    }

    public CombatHit CalculateDamage()
    {
        return new CombatHit
        {
            Damage = 2,
            Delay = 0,
            Type = DamageType.Damage
        };
    }
}