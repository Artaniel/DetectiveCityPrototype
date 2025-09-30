using UnityEngine;
using Assets.Scripts.Worlds;

namespace Assets.Scripts.Crime
{
    public class Crime : MonoBehaviour
    {
        private Boot _boot;
        private CrimeFactory _factory;

        public void Init(Boot boot, CrimeFactory crimeFactory) {
            _boot = boot;
            _factory = crimeFactory;
        }
    }
}