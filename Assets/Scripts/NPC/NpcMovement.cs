using Assets.Scripts.Worlds;
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

        public void TickUpdate (float deltatime) {
            bool found = false;
            foreach(Collider collider in Physics.OverlapSphere(transform.position, 0.01f, ~0, QueryTriggerInteraction.Collide)) {
                Location location = collider.GetComponent<Location>();
                if (!location) continue;
                found = true;
                _npc.state.currentLocation = location;
            }
            if (!found) _boot.world.locationFactory.SetDefaultLocation(_npc);
        }
    }
}