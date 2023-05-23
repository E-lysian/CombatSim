using Combat.Methods.Melee;

namespace Combat;

public interface ICombatManager
{
    bool InCombat { get; set; }
    IEntity Target { get; set; }
    bool IsInitiator { get; set; }
    void Initiate();
    void Attack();
    void TakeDamage(int damage);
    void CheckWonBattle();
    void CheckLostBattle();
    CombatHit CalculateDamage();
}