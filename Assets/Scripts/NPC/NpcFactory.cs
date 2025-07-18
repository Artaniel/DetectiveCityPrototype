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
            foreach (NPC npc in _world.state.npcs){
                npc.Init(_boot, _world);
            }
        }

        public void TickUpdate(float deltaTime) {
            foreach (NPC npc in _world.state.npcs){
                npc.TickUpdate(deltaTime);
            }
        }
    }
}