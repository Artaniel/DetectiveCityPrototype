namespace Assets.Scripts.NPC.NpcAction
{
    using Assets.Scripts.NPC;
    using Assets.Scripts.Worlds;

    public interface INpcAction
    {
        void Init(Boot boot, Npc npc);
        bool CanPerform();
        float GetUtility();
        void Execute();
        void TickUpdate(float deltaTime);
        bool IsComplete();
        Location GetRequiredLocation(); 
    }
}