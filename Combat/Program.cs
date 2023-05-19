using Combat;
using Combat.Methods.Melee;

NPCLoader.Load();
PlayerLoader.Load();

var player = PlayerLoader.Players.FirstOrDefault(x => x.GetType() == typeof(Player));
var npc = NPCLoader.Npcs.FirstOrDefault(x => x.GetType() == typeof(NPC));

if (player == null || npc == null)
    throw new NullReferenceException("Player or NPC os null.");

player.CombatMethod = new MeleeCombat(player);
npc.CombatMethod = new MeleeCombat(npc);

player.CombatTarget = npc;
npc.CombatTarget = player;

player.InCombat = true;
npc.InCombat = true;

while (true)
{
    // Attack Players
    CombatHandler.PerformAttack(PlayerLoader.Players);

    // Attack NPCs
    CombatHandler.PerformAttack(NPCLoader.Npcs);

    /* Reset */
    CombatHandler.ResetCombatTarget(PlayerLoader.Players);
    CombatHandler.ResetCombatTarget(NPCLoader.Npcs);

    Thread.Sleep(600);
    Console.WriteLine("Tick..");
}