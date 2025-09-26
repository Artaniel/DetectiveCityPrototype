namespace Assets.Scripts.Worlds
{
    using UnityEngine;
    using System.Collections.Generic;
    using Assets.Scripts.Items;

    public class Location : MonoBehaviour
    {
        private Boot _boot;
        public enum LocationType {
        Home,
        Work,
        Commercial,
        Bar,
        Street
        }
        
        public string id;
        public LocationType type;
        public List<Location> connectedLocations = new List<Location>();
        public List<Item> inventory;


        public void Init(Boot boot) {
            _boot = boot;
        }
    }
}
