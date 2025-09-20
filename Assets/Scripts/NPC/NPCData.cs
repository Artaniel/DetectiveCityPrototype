namespace Assets.Scripts.NPC
{
    using Assets.Scripts.NPC;
    using Assets.Scripts.Worlds;
    using System.Collections.Generic;
    using Traits;
    using UnityEngine;

    public class NPCData : MonoBehaviour
    {
        private Boot _boot;
        private Npc _npc;

        public string characterName;
        public Location homeLocation;
        public Dictionary<Trait, float> traits = new();

        public Location workLocation;
        public float workStartTime;
        public float workEndTime;

        public void Init(Boot boot, Npc npc) {
            _boot = boot;
            _npc = npc;
        }
    }
} 