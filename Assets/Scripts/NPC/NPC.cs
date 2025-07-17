namespace Assets.Scripts.NPC
{
    using UnityEngine;
    using Assets.Scripts.Worlds;
    using Assets.Scripts.NPC;

    public class NPC : MonoBehaviour
    {
        private Boot _boot;
        private World _world;

        public NPCData data;
        public NPCState state;
        public NpcMetabolism metabolism;
        public NpcAi ai;

        public void Init(Boot boot, World world) {
            _boot = boot;
            _world = world;
            data.Init(boot, this);
            state.Init(boot, this);
            metabolism.Init(boot, this);
            ai.Init(this);
        }

        public void TickUpdate(float deltaTime) {
            metabolism.TickUpdate(deltaTime);
            ai.TickUpdate(deltaTime);
        }
    }
}