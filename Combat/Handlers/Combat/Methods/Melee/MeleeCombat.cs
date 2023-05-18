namespace Combat.Methods.Melee;

public class MeleeCombat : ICombatMethod
{
    private readonly IEntity _entity;

    public MeleeCombat(IEntity entity)
    {
        _entity = entity;
        AttackDistance = _entity.Weapon.Type == WeaponType.HALBERD ? 2 : 1;
    }

    public CombatHit CalculateDamage()
    {
        /* Combat formula etc */
        return new CombatHit
        {
            Damage = 5,
            Delay = 0,
            Type = 1
        };
    }
    
    public void TakeDamage(int damage)
    {
        _entity.Health -= damage;
    }

    public int Tick { get; set; }
    public int AttackDistance { get; set; }

    public CombatHit[] HitCollection { get; set; }
}