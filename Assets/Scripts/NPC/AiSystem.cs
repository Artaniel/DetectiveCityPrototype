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
                    float utility = npc.state.currentAction.GetUtility();
                    
                    Debug.Log($"[{_boot.world.state.currentTimeInMinutes}] {npc.data.characterName}: " +
                             $"State change {previousActionName} to {currentActionName} (Utility={utility:F2})");
                    
                    npc.state.currentAction.Execute();
                    npc.state.isActionComplete = false;
                }
            } else {
                npc.state.currentAction.TickUpdate(deltaTime);
                npc.state.isActionComplete = npc.state.currentAction.IsComplete();
            }
        }

        public INpcAction SelectBestAction(Npc npc) {
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
                if (requiredLocation == null || requiredLocation == npc.state.currentLocation) continue;

                moveTo.SetTarget(requiredLocation);
                utility = action.GetUtility();
                if (utility > bestUtility) {
                    bestUtility = utility;
                    best = moveTo;
                }
            }
            
            return best;
        }
    }
}