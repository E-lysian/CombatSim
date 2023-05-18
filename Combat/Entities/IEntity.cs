namespace Combat;

public interface IEntity
{
    public string Name { get; set; }
    public CombatHandler CombatHandler { get; set; }
    public int AttackSpeed { get; set; }
    public WeaponType WeaponType { get; set; }
}

public enum WeaponType
{
    HALBERD,
    SWORD,
    HAND
}