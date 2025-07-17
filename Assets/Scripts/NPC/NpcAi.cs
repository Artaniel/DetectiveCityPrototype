using Assets.Scripts.NPC;
using Assets.Scripts.NPC.NpcAction;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.NPC
{
    public class NpcAi : MonoBehaviour
    {
        public List<INpcAction> actions = new List<INpcAction>();
        public INpcAction currentAction;
        private NPC _npc;

        public void Init(NPC npc) {
            _npc = npc;
            foreach (INpcAction action in GetComponents<INpcAction>()) {
                action.Init(npc);
                actions.Add(action);
            }
        }

        public void TickUpdate() {
            if (currentAction == null || currentAction.IsComplete()) {
                currentAction = ChooseBestAction();
                if (currentAction != null)
                    currentAction.Execute();
            } else {
                currentAction.Update();
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