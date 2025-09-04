using Assets.Scripts.NPC;
using UnityEngine;

namespace Assets.Scripts.NPC.NpcAction
{
    public class Eat : MonoBehaviour, INpcAction
    {
        private Boot _boot;
        private Npc _npc;
        public bool isComplete;
        public float hungerReductionRate = 0.1f;
        
        public void Init(Boot boot, Npc npc) {
            _boot = boot;
            _npc = npc;
        }

        public bool CanPerform() {
            return _npc.state.currentLocation.id == "HomeNPC1";
        }

        public float GetUtility() {
            return _npc.state.hunger / 100f;
        }

        public void Execute() {
            isComplete = false;
            _npc.state.currentActivity = "Eating";
        }

        public void TickUpdate(float deltaTime) {
            if (isComplete) return;
                        
            _npc.state.hunger -= hungerReductionRate;
            
            if (_npc.state.hunger <= 0) {
                _npc.state.hunger = 0;
                isComplete = true;
            }
        }

        public bool IsComplete() {
            return isComplete;
        }
    }
}