namespace Assets.Scripts.NPC
{
    using UnityEngine;
    using Assets.Scripts.Worlds;

    public class NPC : MonoBehaviour
    {
        private Boot _boot;
        private World _world;

        public NPCData data;
        public NPCState state;

        public void Init(Boot boot, World world) {
            _boot = boot;
            _world = world;
            data.Init(boot, this);
            state.Init(boot, this);
        }
    }
} 