using Assets.Scripts.NPC;
using Assets.Scripts.NPC.NpcAction;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.NPC
{
    public class NpcAi : MonoBehaviour
    {
        private Boot _boot;
        private NPC _npc;
        public List<INpcAction> actions = new List<INpcAction>();
        public INpcAction currentAction;

        public void Init(Boot boot, NPC npc) {
            _boot = boot;
            _npc = npc;
            foreach (INpcAction action in GetComponents<INpcAction>()) {
                action.Init(boot, npc);
                actions.Add(action);
            }
        }

        public void TickUpdate(float deltaTime) {
            if (currentAction == null || currentAction.IsComplete()) {
                currentAction = ChooseBestAction();
                if (currentAction != null)
                    currentAction.Execute();
            } else {
                currentAction.TickUpdate(deltaTime);
            }
        }

        private INpcAction ChooseBestAction() {
            INpcAction best = null;
            float bestUtility = float.MinValue;
            foreach (INpcAction action in actions) {
                if (action.CanPerform()) {
                    float utility = action.GetUtility();
                    if (utility > bestUtility) {
                        bestUtility = utility;
                        best = action;
                    }
                }
            }
            return best;
        }
    }
}