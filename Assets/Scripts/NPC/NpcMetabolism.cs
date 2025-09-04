using UnityEngine;

namespace Assets.Scripts.NPC
{
    public class NpcMetabolism : MonoBehaviour
    {
        private Boot _boot;
        private Npc _npc;
        public float hungerSpeed = 0.001f;
        public float energyExhaustionSpeed = 0.001f;

        public void Init(Boot boot, Npc npc) {            
            _boot = boot;
            _npc = npc;
        }

        public virtual void TickUpdate(float deltaTime) {
            _npc.state.hunger += hungerSpeed * deltaTime;
            _npc.state.energy -= energyExhaustionSpeed * deltaTime;
        }
    }
}