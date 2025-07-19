namespace Assets.Scripts.Worlds
{
    using Assets.Scripts.NPC;
    using Assets.Scripts.Worlds;
    using UnityEngine;

    public class World : MonoBehaviour
    {
        private Boot _boot;
        public WorldState state;
        public Clock clock;
        public NpcFactory npcFactory;
        public LocationFactory locationFactory;

        public void Init(Boot boot) {
            _boot = boot;
            state.Init(boot, this);
            clock.Init(boot, this);
            locationFactory.Init(boot, this);
            npcFactory.Init(boot, this);
        }
    }    
} 