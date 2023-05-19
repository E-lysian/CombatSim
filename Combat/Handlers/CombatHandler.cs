namespace Combat;

public class CombatHandler
{
    public static void PerformAttack(IEnumerable<IEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity == null) continue;
            entity.CombatMethod.Attack();
        }
    }

    public static void ResetCombatTarget(IEnumerable<IEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity == null) continue;
            if (entity.ResetCombat)
                entity.CombatTarget = null;
        }
    }
}