using UnityEngine;
using UnityEngine.AI;


namespace Assets.Scripts.NPC
{
    public class NpcMovement : MonoBehaviour
    {
        private Boot _boot;
        private Npc _npc;
        public NavMeshAgent agent;

        public void Init(Boot boot, Npc npc) {
            _boot = boot;
            _npc = npc;
        }
    }
}