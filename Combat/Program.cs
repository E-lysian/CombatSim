using Combat;
using Combat.Methods.Melee;

NPCLoader.Load();
PlayerLoader.Load();

var player = PlayerLoader.Players.FirstOrDefault(x => x.GetType() == typeof(Player)) ??
             throw new ArgumentNullException(typeof(Player).ToString());
var npc = NPCLoader.Npcs.FirstOrDefault(x => x.GetType() == typeof(NPC)) ??
          throw new ArgumentNullException(typeof(NPC).ToString());

player.CombatMethod = new MeleeCombat(player);
npc.CombatMethod = new MeleeCombat(npc);

player.CombatTarget = npc;
npc.CombatTarget = player;

player.InCombat = true;
npc.InCombat = true;

while (true)
{
    player.CombatMethod.Attack();
    npc.CombatMethod.Attack();

    if (player.CombatTarget?.Health <= 0)
    {
        ConsoleColorHandler.Broadcast(0,
            $"{player.Name} won over {player.CombatTarget.Name}. Remaining health: {player.Health}");
        ConsoleColorHandler.Broadcast(1, $"{player.Name} Resetting combat.. ");
        player.CombatTarget = null;
    }

    if (npc.CombatTarget?.Health <= 0)
    {
        ConsoleColorHandler.Broadcast(0,
            $"{npc.Name} won over {npc.CombatTarget.Name}. Remaining health: {npc.Health}");
        ConsoleColorHandler.Broadcast(1, $"{npc.Name} Resetting combat.. ");
        npc.CombatTarget = null;
    }

    /* Reset */
    if (player.CombatTarget == null || npc.CombatTarget == null)
        player.CombatTarget = npc.CombatTarget = null;

    Thread.Sleep(600);
    Console.WriteLine("Tick..");
}