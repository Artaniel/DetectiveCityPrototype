namespace Assets.Scripts.Worlds
{
    using Assets.Scripts.NPC;
    using UnityEngine;

    public class World : MonoBehaviour
    {
        private Boot _boot;
        public WorldState state;
        public Clock clock;
        public NpcFactory npcFactory;

        public void Init(Boot boot) {
            _boot = boot;
            state.Init(boot, this);
            clock.Init(boot, this);
            npcFactory.Init(boot, this);
        }
    }    
} 