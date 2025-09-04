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

        public void Init(Boot boot) {
            _boot = boot;
        }

        // Placeholder for the AI tick update, which will be called by NPCs
        public void TickUpdate(Npc npc, float deltaTime) {
            // This method will contain the logic for selecting and executing actions for a given NPC.
            // For now, it's a placeholder.
        }

        // Placeholder for selecting the best action for an NPC
        public INpcAction SelectBestAction(Npc npc) {
            // This method will contain the utility AI logic to choose the best action.
            // For now, it's a placeholder.
            return null;
        }
    }
}