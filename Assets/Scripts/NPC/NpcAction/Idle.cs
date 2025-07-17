using Assets.Scripts.NPC;
using UnityEngine;

namespace Assets.Scripts.NPC.NpcAction
{
    public class Idle : MonoBehaviour, INpcAction
    {
        public bool isComplete;
        public float idleUtility = 0.1f;
        private NPC _npc;

        public void Init(NPC npc) {
            _npc = npc;
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

        public void Update() {            
        }

        public bool IsComplete() {
            return isComplete;
        }
    }
}
