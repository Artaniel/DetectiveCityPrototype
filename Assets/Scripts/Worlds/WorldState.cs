namespace Assets.Scripts.Worlds
{
    using System.Collections.Generic;
    using Scripts.NPC;

    public class WorldState
    {
        private Boot _boot;
        private World _world;

        public int currentTimeInMinutes;
        public List<Location> Locations = new List<Location>();
        public List<NPC> NPCs = new List<NPC>();
        //public List<CrimeEvent> ActiveCrimes = new List<CrimeEvent>();

        public void Init(Boot boot, World world){
            _boot = boot;
            _world = world;
        }
    }
} 