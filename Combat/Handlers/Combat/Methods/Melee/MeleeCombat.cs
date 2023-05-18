namespace Combat.Methods.Melee;

public class MeleeCombat : ICombatMethod
{
    private readonly IEntity _entity;

    public MeleeCombat(IEntity entity)
    {
        _entity = entity;
        AttackDistance = _entity.Weapon.Type == WeaponType.HALBERD ? 2 : 1;
    }

    public CombatHit PerformDamage()
    {
        /* Combat formula etc */
        return new CombatHit
        {
            Damage = new Random().Next(0, 10),
            Delay = 0,
            Type = 1
        };
    }

    public int AttackDistance { get; set; }


    public CombatHit[] HitCollection { get; set; }
}