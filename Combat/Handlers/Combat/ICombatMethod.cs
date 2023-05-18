namespace Combat.Methods.Melee;

public interface ICombatMethod
{
    public int AttackDistance { get; set; }
    public CombatHit[] HitCollection { get; set; } /* Used for special attacks such as dds etc.. */
    CombatHit PerformDamage();
}