using Assets.Scripts.NPC;
using Assets.Scripts.Worlds;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.NPC.NpcAction
{
    public class MoveTo : MonoBehaviour, INpcAction
    {
        
        private Boot _boot;
        private AiSystem _ai;
        private LocationFactory _locationFactory;
        public Location targetLocation;
        public float moveUtility = 0.5f;
        private List<Location> _path = new List<Location>();
        private int _currentStep = 0;

        public void Init(Boot boot, AiSystem ai) {
            _boot = boot;
            _locationFactory = _boot.world.locationFactory;
        }

        public void SetTarget(Location location, Npc npc) {
            targetLocation = location;
            npc.state.isActionComplete = false;
            _currentStep = 0;
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
            if (_path.Count == 0) {
                CalculatePath(npc);
            }
        }

        public void TickUpdate(float deltaTime, Npc npc) {
            if (npc.state.isActionComplete || _path.Count == 0) return;
            if (_currentStep < _path.Count) {
                npc.state.currentLocation = _path[_currentStep];
                _currentStep++;
                if (npc.state.currentLocation == targetLocation) {
                    npc.state.isActionComplete = true;
                }
            } else {
                npc.state.isActionComplete = true;
            }
        }

        public bool IsComplete(Npc npc) {
            return npc.state.isActionComplete;
        }

        private void CalculatePath(Npc npc) {
            _path.Clear();
            if (_locationFactory != null) {
                _path = _locationFactory.FindPath(npc.state.currentLocation, targetLocation);
                _currentStep = 0;
            }
        }

        public Location GetRequiredLocation(Npc npc) {
            return null; 
        }
    }
}
