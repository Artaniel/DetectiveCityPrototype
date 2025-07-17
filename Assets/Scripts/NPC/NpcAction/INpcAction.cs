namespace Assets.Scripts.NPC.NpcAction
{
    using Assets.Scripts.NPC;

    public interface INpcAction
    {
        void Init(NPC npc);
        bool CanPerform();
        float GetUtility();
        void Execute();
        void Update();
        bool IsComplete();
    }
}