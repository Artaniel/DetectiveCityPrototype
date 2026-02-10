using Assets.Scripts.Worlds;
using UnityEngine;

namespace Assets.Scripts.NPC.NpcAction
{
    public class MoveTo : MonoBehaviour, INpcAction
    {
        
        private Boot _boot;
        private AiSystem _ai;
        private LocationFactory _locationFactory;
        public Location targetLocation;
        public float moveUtility = 0.5f;

        public void Init(Boot boot, AiSystem ai) {
            _boot = boot;
            _locationFactory = _boot.world.locationFactory;
        }

        public void SetTarget(Location location, Npc npc) {
            targetLocation = location;
            npc.state.isActionComplete = false;
            CalculatePath(npc);
        }

        public bool CanPerform(Npc npc) {
            return targetLocation != null && npc.state.currentLocation != targetLocation;
        }

        public float GetUtility(Npc npc) {
            return moveUtility;
        }

        public void Execute(Npc npc) {
            npc.state.isActionComplete = false;
            npc.state.currentActivity = $"MoveTo({targetLocation?.description})";
            CalculatePath(npc);
        }

        public void TickUpdate(float deltaTime, Npc npc) {
            if (npc.state.isActionComplete) return;
            if (npc.state.currentLocation == targetLocation) {
                npc.state.isActionComplete = true;
            }            
        }

        public bool IsComplete(Npc npc) {
            return npc.state.isActionComplete;
        }

        private void CalculatePath(Npc npc) {
            npc.movement.agent.SetDestination(targetLocation.GetValidPoint());
        }

        public Location GetRequiredLocation(Npc npc) {
            return null; 
        }
    }
}
