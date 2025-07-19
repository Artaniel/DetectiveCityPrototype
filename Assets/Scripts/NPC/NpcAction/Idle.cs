using Assets.Scripts.NPC;
using UnityEngine;

namespace Assets.Scripts.NPC.NpcAction
{
    public class Idle : MonoBehaviour, INpcAction
    {
        private Boot _boot;
        private NPC _npc;
        public bool isComplete;
        public float idleUtility = 0.1f;

        public void Init(Boot boot, NPC npc) {
            _npc = npc;
            _boot = boot;
        }

        public bool CanPerform() {
            return true;
        }

        public float GetUtility() {
            return idleUtility;
        }

        public void Execute() {
            isComplete = true;
            _npc.state.currentActivity = "Idle";
        }

        public void TickUpdate(float deltaTime) {            
        }

        public bool IsComplete() {
            return isComplete;
        }
    }
}
