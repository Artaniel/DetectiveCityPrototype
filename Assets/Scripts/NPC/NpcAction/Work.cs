using Assets.Scripts.NPC;
using Assets.Scripts.Worlds;
using UnityEngine;

namespace Assets.Scripts.NPC.NpcAction
{
    public class Work : MonoBehaviour, INpcAction
    { 
        private Boot _boot;
        private Npc _npc;
        public float maxUtility;
        public bool isComplete = false;
        public float energyExaustSpeed;
        public float minimalEnergy = 0.10f;
        
        public void Init(Boot boot, Npc npc) {
            _boot = boot;
            _npc = npc;
        }
        
        public bool CanPerform() {
            return _npc.data.workLocation != null;
        }

        public float GetUtility() {
            float currentTime = _boot.world.state.currentTimeInMinutes;
            if (currentTime < _npc.data.workStartTime) return 0f;
            if (currentTime > _npc.data.workEndTime) return 0f;
            float worksShiftDuration = _npc.data.workEndTime - _npc.data.workStartTime;
            float timeLeftInShift = _npc.data.workEndTime - currentTime;
            float utility = maxUtility * (timeLeftInShift / worksShiftDuration);
            return utility;
        }

        public void Execute() { 
            isComplete = false;
            _npc.state.currentActivity = "Wroking";
        }

        public void TickUpdate(float deltaTime) {
            _npc.state.energy -= energyExaustSpeed * deltaTime;
            if (_npc.state.energy < minimalEnergy) {
                _npc.state.energy = minimalEnergy;
                isComplete = true;
            }
            if (_boot.world.state.currentTimeInMinutes > _npc.data.workEndTime) {
                isComplete = true;
            }
        }

        public bool IsComplete() {
            return isComplete;
        }

        public Location GetRequiredLocation() => _npc.data.workLocation;
    }
}