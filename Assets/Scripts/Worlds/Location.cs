namespace Assets.Scripts.Worlds
{
    using UnityEngine;
    using System.Collections.Generic;

    public enum LocationType {
        Home,
        Work,
        Commercial,
        Bar,
        Street
    }

    public class Location : MonoBehaviour
    {
        [SerializeField] private string id;
        [SerializeField] private LocationType type;
        [SerializeField] private List<string> connectedLocationsIDs = new List<string>();

        private Boot _boot;

        public void Init(Boot boot) {
            _boot = boot;
        }

        public string ID => id;
        public LocationType Type => type;
        public List<string> ConnectedLocationsIDs => connectedLocationsIDs;
    }
}
