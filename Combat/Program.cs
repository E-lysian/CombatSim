using Combat;
using Combat.Handlers.Combat;
using Combat.Methods.Melee;

NPCLoader.Load();
var player = NPCLoader.Entities.FirstOrDefault(x => x.GetType() == typeof(Player));
var npc = NPCLoader.Entities.FirstOrDefault(x => x.GetType() == typeof(NPC));

player.CombatMethod = new MeleeCombat(player);
npc.CombatMethod = new MeleeCombat(npc);

player.CombatTarget = npc;
npc.CombatTarget = player;

player.InCombat = true;
npc.InCombat = true;

var combatFactory = new CombatFactory();
while (true)
{
    foreach (var entity in NPCLoader.Entities.Where(x => x.InCombat).ToList())
        combatFactory.Attack(entity);

    Thread.Sleep(600);
    Console.WriteLine("Tick..");
}