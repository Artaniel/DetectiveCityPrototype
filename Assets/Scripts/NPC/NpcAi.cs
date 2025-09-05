using Assets.Scripts.NPC;
using Assets.Scripts.NPC.NpcAction;
using Assets.Scripts.Worlds;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.NPC
{
    public class NpcAi : MonoBehaviour
    {
        private Boot _boot;
        private Npc _npc;
        public List<INpcAction> actions = new List<INpcAction>();
        public INpcAction currentAction;
        private MoveTo moveToAction; 

        public void Init(Boot boot, Npc npc) {
            _boot = boot;
            _npc = npc;
            foreach (INpcAction action in GetComponents<INpcAction>()) {
                action.Init(boot, npc);
                actions.Add(action);
                
                if (action is MoveTo moveTo) moveToAction = moveTo;
            }
        }

        public void TickUpdate(float deltaTime) {
            if (currentAction == null || currentAction.IsComplete()) {
                INpcAction previousAction = currentAction;
                currentAction = ChooseBestAction();
                
                if (currentAction != null) {
                    string previousActionName = previousAction?.GetType().Name ?? "None";
                    string currentActionName = currentAction.GetType().Name;
                    float utility = currentAction.GetUtility();
                    
                    Debug.Log($"[{_boot.world.state.currentTimeInMinutes}] {_npc.data.characterName}: " +
                             $"State change {previousActionName} to {currentActionName} (Utility={utility:F2})");
                    
                    currentAction.Execute();
                }
            } else {
                currentAction.TickUpdate(deltaTime);
            }
        }

        private INpcAction ChooseBestAction() {
            INpcAction best = null;
            float utility = 0f;
            float bestUtility = float.MinValue;
            foreach (INpcAction action in actions) {
                if (action.CanPerform()) {
                    utility = action.GetUtility();
                    if (utility <= bestUtility) continue;
                    bestUtility = utility;
                    best = action;                    
                    continue;
                }
                    
                Location requiredLocation = action.GetRequiredLocation();
                if (requiredLocation == null || requiredLocation == _npc.state.currentLocation) continue;

                moveToAction.SetTarget(requiredLocation);
                utility = action.GetUtility();
                if (utility > bestUtility) {
                    bestUtility = utility;
                    best = moveToAction;
                }
            }
            
            return best;
        }
    }
}