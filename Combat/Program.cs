using Combat;
using Combat.Methods.Melee;

NPCLoader.Load();
PlayerLoader.Load();
var _player = PlayerLoader.Players.FirstOrDefault(x => x.GetType() == typeof(Player));
var _npc = NPCLoader.Npcs.FirstOrDefault(x => x.GetType() == typeof(NPC));

_player.CombatMethod = new MeleeCombat(_player);
_npc.CombatMethod = new MeleeCombat(_npc);

_player.CombatTarget = _npc;
_npc.CombatTarget = _player;

_player.InCombat = true;
_npc.InCombat = true;

while (true)
{
    _player.Attack();
    _npc.Attack();
    
    if (_player?.CombatTarget?.Health <= 0)
    {
        ConsoleColorHandler.Broadcast(0,
            $"{_player.Name} won over {_player.CombatTarget.Name}. Remaining health: {_player.Health}");
        ConsoleColorHandler.Broadcast(1, $"{_player.Name} Resetting combat.. ");
        _player.CombatTarget = null;
    }

    if (_npc?.CombatTarget?.Health <= 0)
    {
        ConsoleColorHandler.Broadcast(0,
            $"{_npc.Name} won over {_npc.CombatTarget.Name}. Remaining health: {_npc.Health}");
        ConsoleColorHandler.Broadcast(1, $"{_npc.Name} Resetting combat.. ");
        _npc.CombatTarget = null;
    }

    /* Reset */
    if (_player.CombatTarget == null || _npc.CombatTarget == null)
    {
        _player.CombatTarget = null;
        _npc.CombatTarget = null;
    }

    Thread.Sleep(600);
    Console.WriteLine("Tick..");
}