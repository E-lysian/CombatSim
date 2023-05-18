namespace Combat;

public class CombatHandler
{
    private IEntity? _target;
    private int _tick;
    public int AttackSpeed { get; set; }
    public IEntity? Attacker { get; set; }

    public void HandleEngage(IEntity target)
    {
        if (Attacker != null) _target = target;
        if (_target != null) _target.CombatHandler._target = Attacker;
        _tick = AttackSpeed;
    }

    public void HandleAttack()
    {
        _tick++;
        if (_target != null)
            if (_tick % AttackSpeed == 0)
            {
                ConsoleColorHandler.HandleConsoleColor(Attacker);
                Console.WriteLine($"{Attacker?.Name} Performing attack.. ");
                ConsoleColorHandler.ResetColor();
            }
    }
}