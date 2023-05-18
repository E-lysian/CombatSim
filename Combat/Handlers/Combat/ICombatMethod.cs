namespace Combat.Methods.Melee;

public interface ICombatMethod
{
    public int Tick { get; set; }
    public int AttackDistance { get; set; }
    public CombatHit[] HitCollection { get; set; } /* Used for special attacks such as dds etc.. */
    CombatHit CalculateDamage();
    void TakeDamage(int damage);
}