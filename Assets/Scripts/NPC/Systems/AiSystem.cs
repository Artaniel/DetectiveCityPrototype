namespace Assets.Scripts.NPC
{
    using System.Collections.Generic;
    using UnityEngine;
    using Assets.Scripts.Worlds;
    using Assets.Scripts;
    using Assets.Scripts.NPC.NpcAction;

    public class AiSystem : MonoBehaviour
    {
        private Boot _boot;
        public List<INpcAction> actions = new List<INpcAction>();
        public Idle idle;
        public MoveTo moveTo;
        public Eat eat;
        public Work work;

        public void Init(Boot boot) {
            _boot = boot;
            CreateBaseActions();
            foreach (INpcAction action in actions) {
                action.Init(boot, null);
            }
        }

        private void CreateBaseActions() {
            actions.Add(idle);
            actions.Add(eat);
            actions.Add(moveTo);
            actions.Add(work);
        }

        public void TickUpdate(Npc npc, float deltaTime) {
            if (npc.state.currentAction == null || npc.state.isActionComplete) {
                INpcAction previousAction = npc.state.currentAction;
                npc.state.currentAction = SelectBestAction(npc);
                
                if (npc.state.currentAction != null) {
                    string previousActionName = previousAction?.GetType().Name ?? "None";
                    string currentActionName = npc.state.currentAction.GetType().Name;
                    float utility = npc.state.currentAction.GetUtility(npc);
                    
                    Debug.Log($"[{_boot.world.state.currentTimeInMinutes}] {npc.data.characterName}: " +
                             $"State change {previousActionName} to {currentActionName} (Utility={utility:F2})");
                    
                    npc.state.currentAction.Execute(npc);
                    npc.state.isActionComplete = false;
                }
            } else {
                npc.state.currentAction.TickUpdate(deltaTime, npc);
                npc.state.isActionComplete = npc.state.currentAction.IsComplete(npc);
            }
        }

        public INpcAction SelectBestAction(Npc npc) {
            INpcAction best = null;
            float utility = 0f;
            float bestUtility = float.MinValue;
            bool isLogging = npc.state.isLoggingActions;
            
            foreach (INpcAction action in actions) {
                if (action.CanPerform(npc)) {
                    utility = action.GetUtility(npc);
                    if (isLogging) {
                        // log utility
                    }
                    if (utility <= bestUtility) continue;
                    bestUtility = utility;
                    best = action;                    
                    continue;
                } else { 
                    // set -1 to utility log
                }

                Location requiredLocation = action.GetRequiredLocation(npc);
                if (requiredLocation == null || requiredLocation == npc.state.currentLocation) continue;

                moveTo.SetTarget(requiredLocation, npc);
                utility = action.GetUtility(npc);
                if (utility > bestUtility) {
                    bestUtility = utility;
                    best = moveTo;
                }
            }
            
            return best;
        }
    }
}