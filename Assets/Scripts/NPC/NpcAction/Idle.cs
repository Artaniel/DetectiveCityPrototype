using Assets.Scripts.NPC;
using Assets.Scripts.Worlds;
using UnityEngine;

namespace Assets.Scripts.NPC.NpcAction
{
    public class Idle : MonoBehaviour, INpcAction
    {
        private Boot _boot;
        private AiSystem _ai;
        public float idleUtility = 0.1f;

        public void Init(Boot boot, AiSystem ai) {
            _ai = ai;
            _boot = boot;
        }

        public bool CanPerform(Npc npc) {
            return true;
        }

        public float GetUtility(Npc npc) {
            return idleUtility;
        }

        public void Execute(Npc npc) {
            npc.state.isActionComplete = true;
            npc.state.currentActivity = "Idle";
        }

        public void TickUpdate(float deltaTime, Npc npc) {            
        }

        public bool IsComplete(Npc npc) {
            return npc.state.isActionComplete;
        }

        public Location GetRequiredLocation(Npc npc) {
            return null;
        }
    }
}
