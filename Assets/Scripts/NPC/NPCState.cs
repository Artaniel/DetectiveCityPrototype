namespace Assets.Scripts.NPC
{
    using Assets.Scripts.NPC;
    using Assets.Scripts.Worlds;
    using UnityEngine;
    using Assets.Scripts.NPC.NpcAction;
    using System.Collections.Generic;
    using Assets.Scripts.Items;

    public class NPCState : MonoBehaviour
    {
        private Boot _boot;
        private Npc _npc;

        public Location currentLocation;
        public float hunger;
        public float energy;
        public string currentActivity;
        public INpcAction currentAction;
        public bool isActionComplete;

        public List<Item> inventory;
        public bool isLoggingActions = false;

        public void Init(Boot boot, Npc npc) {
            _boot = boot;
            _npc = npc;
        }
    }
} 