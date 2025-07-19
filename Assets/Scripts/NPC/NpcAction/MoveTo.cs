using Assets.Scripts.NPC;
using Assets.Scripts.Worlds;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.NPC.NpcAction
{
    public class MoveTo : MonoBehaviour, INpcAction
    {
        
        private Boot _boot;
        private NPC _npc;
        private LocationFactory _locationFactory;
        public bool isComplete;
        public Location targetLocation;
        public float moveUtility = 0.5f;
        private List<Location> _path = new List<Location>();
        private int _currentStep = 0;

        public void Init(Boot boot, NPC npc) {
            _boot = boot;
            _npc = npc;
            _locationFactory = _boot.world.locationFactory;
        }

        public void SetTarget(Location location) {
            targetLocation = location;
            isComplete = false;
            _currentStep = 0;
            CalculatePath();
        }

        public bool CanPerform() {
            return targetLocation != null && _npc.state.currentLocation != targetLocation;
        }

        public float GetUtility() {
            return moveUtility;
        }

        public void Execute() {
            isComplete = false;
            _npc.state.currentActivity = $"MoveTo({targetLocation?.id})";
            if (_path.Count == 0) {
                CalculatePath();
            }
        }

        public void TickUpdate(float deltaTime) {
            if (isComplete || _path.Count == 0) return;
            // Перемещаемся на следующий шаг
            if (_currentStep < _path.Count) {
                _npc.state.currentLocation = _path[_currentStep];
                _currentStep++;
                if (_npc.state.currentLocation == targetLocation) {
                    isComplete = true;
                }
            } else {
                isComplete = true;
            }
        }

        public bool IsComplete() {
            return isComplete;
        }

        private void CalculatePath() {
            _path.Clear();
            if (_locationFactory != null) {
                _path = _locationFactory.FindPath(_npc.state.currentLocation, targetLocation);
                _currentStep = 0;
            }
        }
    }
}
