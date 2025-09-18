namespace Assets.Scripts.NPC.NpcAction
{
    using Assets.Scripts.NPC;
    using Assets.Scripts.Worlds;

    public interface INpcAction
    {
        void Init(Boot boot, AiSystem ai);
        bool CanPerform(Npc npc);
        float GetUtility(Npc npc);
        void Execute(Npc npc);
        void TickUpdate(float deltaTime, Npc npc);
        bool IsComplete(Npc npc);
        Location GetRequiredLocation(Npc npc); 
    }
}