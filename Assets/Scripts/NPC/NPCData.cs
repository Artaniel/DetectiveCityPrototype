namespace Assets.Scripts.NPC
{
    using Assets.Scripts.NPC;
    using Assets.Scripts.Worlds;
    using System.Collections.Generic;
    using UnityEngine;

    public class NPCData : MonoBehaviour
    {
        private Boot _boot;
        private NPC _npc;

        public string characterName;
        public Location homeLocation;
        public Location workLocation;
        public int workStartTime;
        public int workEndTime;
        public Dictionary<string, float> traits = new();

        public void Init(Boot boot, NPC npc) {
            _boot = boot;
            _npc = npc;
        }
    }
} 