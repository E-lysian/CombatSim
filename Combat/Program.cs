using Combat;
using Combat.Methods.Melee;

NPCLoader.Load();
PlayerLoader.Load();

var player = PlayerLoader.Players.FirstOrDefault(x => x.GetType() == typeof(Player));
var npc = NPCLoader.Npcs.FirstOrDefault(x => x.GetType() == typeof(NPC));

if (player == null || npc == null)
    throw new NullReferenceException("Player or NPC is null.");


player.MeleeCombatManager.Target = npc;
player.MeleeCombatManager.IsInitiator = true;

npc.MeleeCombatManager.Target = player;

while (true)
{
    if (Math.Abs(player.Y - npc.Y) <= 1)
    {
        Console.WriteLine("Within range..");
        player.MeleeCombatManager.Attack();
        npc.MeleeCombatManager.Attack();
        
        player.MeleeCombatManager.CheckWonBattle();
        player.MeleeCombatManager.CheckLostBattle();
        
        npc.MeleeCombatManager.CheckWonBattle();
        npc.MeleeCombatManager.CheckLostBattle();
    }
    else
    {
        Console.WriteLine("Not within range..");
        player.Y += 1;
    }

    Thread.Sleep(600);
    Console.WriteLine("Tick..");
}