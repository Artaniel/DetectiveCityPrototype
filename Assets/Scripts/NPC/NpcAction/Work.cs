using Assets.Scripts.NPC;
using Assets.Scripts.Worlds;
using UnityEngine;

namespace Assets.Scripts.NPC.NpcAction
{
    public class Work : MonoBehaviour, INpcAction
    { 
        private Boot _boot;
        private AiSystem _ai;
        public float maxUtility;
        public float energyExaustSpeed;
        public float minimalEnergy = 0.10f;
        
        public void Init(Boot boot, AiSystem ai) {
            _ai = ai;
            _boot = boot;
        }
        
        public bool CanPerform(Npc npc) {
            return npc.data.workLocation != null;
        }

        public float GetUtility(Npc npc) {
            float currentTime = _boot.world.state.currentTimeInMinutes;
            if (currentTime < npc.data.workStartTime) return 0f;
            if (currentTime > npc.data.workEndTime) return 0f;
            float worksShiftDuration = npc.data.workEndTime - npc.data.workStartTime;
            float timeLeftInShift = npc.data.workEndTime - currentTime;
            return maxUtility * (timeLeftInShift / worksShiftDuration);
        }

        public void Execute(Npc npc) { 
            npc.state.isActionComplete = false;
            npc.state.currentActivity = "Working";
        }

        public void TickUpdate(float deltaTime, Npc npc) {
            npc.state.energy -= energyExaustSpeed * deltaTime;
            if (npc.state.energy < minimalEnergy) {
                npc.state.energy = minimalEnergy;
                npc.state.isActionComplete = true;
            }
            if (_boot.world.state.currentTimeInMinutes > npc.data.workEndTime) {
                npc.state.isActionComplete = true;
            }
        }

        public bool IsComplete(Npc npc) {
            return npc.state.isActionComplete;
        }

        public Location GetRequiredLocation(Npc npc) => npc.data.workLocation;
    }
}