using UnityEngine;
using Assets.Scripts.Worlds;

namespace Assets.Scripts.Crime
{
    public class CrimeFactory : MonoBehaviour
    {
        private Boot _boot;
        private World _world;

        public void Init(Boot boot, World world) {
            _boot = boot;
            _world = world;
        }

    }
}