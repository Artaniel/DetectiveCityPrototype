using UnityEngine;
using Assets.Scripts.Worlds;
using System.Collections.Generic;
using Assets.Scripts.NPC;
using Assets.Scripts.Items;

namespace Assets.Scripts.Crime
{
    public enum CrimeStatus {
        Open,
        Closed
    }

    public enum CrimeResolution {
        None,
        Caught,
        Mistake
    }

    public class Crime : MonoBehaviour
    {
        private Boot _boot;
        private CrimeFactory _factory;
        public float timeStamp;
        public Location location;
        public Item stolenItem;
        public Npc criminal;
        public List<Npc> suspects;
        public CrimeStatus status;
        public CrimeResolution resolution;
        public string notes;

        public void Init(Boot boot, CrimeFactory crimeFactory) {
            _boot = boot;
            _factory = crimeFactory;
        }

        public void Build(float timeStamp, Location location, Item stolenItem, Npc criminal, List<Npc> suspects, string notes) {
            this.timeStamp = timeStamp;
            this.location = location;
            this.stolenItem = stolenItem;
            this.criminal = criminal;
            this.suspects = suspects;
            this.status = CrimeStatus.Open;
            this.resolution = CrimeResolution.None;
            this.notes = notes;
        }
    }
}