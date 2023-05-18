using Combat;

NPCLoader.Load();
var player = NPCLoader.Entities.FirstOrDefault(x => x.GetType() == typeof(Player));
var npc = NPCLoader.Entities.FirstOrDefault(x => x.GetType() == typeof(NPC));

if (npc != null) player?.CombatHandler.HandleEngage(npc);

while (true)
{
    Console.WriteLine("Tick..");
    foreach (var entity in NPCLoader.Entities)
        entity.CombatHandler.HandleAttack();

    Thread.Sleep(600);
}