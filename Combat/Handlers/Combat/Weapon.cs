using Combat.Methods.Melee;

namespace Combat;

public record Weapon(int ItemId, int LevelReq, int Speed, CombatAnimations animation, WeaponType Type);