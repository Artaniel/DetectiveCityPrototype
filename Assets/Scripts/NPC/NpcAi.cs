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

        public void Init(Boot boot, Npc npc) {
            _boot = boot;
            _npc = npc;
        }

        public void TickUpdate(float deltaTime) {
            _boot.aiSystem.TickUpdate(_npc, deltaTime);
        }
    }
}