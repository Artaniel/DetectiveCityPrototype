namespace Assets.Scripts.NPC.NpcAction
{
    using Assets.Scripts.NPC;

    public interface INpcAction
    {
        void Init(Boot boot, NPC npc);
        bool CanPerform();
        float GetUtility();
        void Execute();
        void TickUpdate(float deltaTime);
        bool IsComplete();
    }
}