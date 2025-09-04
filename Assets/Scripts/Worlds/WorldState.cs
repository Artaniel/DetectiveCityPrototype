namespace Assets.Scripts.Worlds
{
    using UnityEngine;
    using System.Collections.Generic;
    using Scripts.NPC;

    public class WorldState : MonoBehaviour
    {
        private Boot _boot;
        private World _world;

        public int currentTimeInMinutes;
        public List<Location> locations = new List<Location>();
        public List<Npc> npcs = new List<Npc>();
        //public List<CrimeEvent> ActiveCrimes = new List<CrimeEvent>();

        public void Init(Boot boot, World world){
            _boot = boot;
            _world = world;
        }
    }
} 