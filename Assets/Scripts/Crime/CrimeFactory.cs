using UnityEngine;
using Assets.Scripts.Worlds;
using Assets.Scripts.Items;
using Assets.Scripts.NPC;
using System.Collections.Generic;

namespace Assets.Scripts.Crime
{
    public class CrimeFactory : MonoBehaviour
    {
        private Boot _boot;
        private World _world;
        public Crime crimePrefab;

        public void Init(Boot boot, World world) {
            _boot = boot;
            _world = world;
        }

        public void CreateCrime(float timeStamp, Location location, Item stolenItem, Npc criminal, List<Npc> suspects, string notes){
            Crime crime = Instantiate(crimePrefab, transform);
            _world.state.crimes.Add(crime);
            crime.Init(_boot, this);
            crime.Build(timeStamp, location, stolenItem, criminal, suspects, notes);
        }

    }
}