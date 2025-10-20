using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.Worlds;
using System.Collections.Generic;

namespace Assets.Scripts.NPC
{
    public class NpcFactory : MonoBehaviour
    {
        private Boot _boot;
        private World _world;

        public void Init(Boot boot, World world) {
            _boot = boot;
            _world = world;
            foreach (Npc npc in _world.state.npcs){
                npc.Init(_boot, _world);
            }
        }

        public void TickUpdate(float deltaTime) {
            foreach (Npc npc in _world.state.npcs){
                npc.TickUpdate(deltaTime);
            }
        }

        public List<Npc> GetNpcsInLocation(Location location){
            List<Npc> npcsInLocation = new List<Npc>();
            foreach (Npc npc in _world.state.npcs){
                if (npc.state.currentLocation == location){
                    npcsInLocation.Add(npc);
                }
            }
            return npcsInLocation;
        }
    }
}