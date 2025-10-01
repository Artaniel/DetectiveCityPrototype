using UnityEngine;
using Assets.Scripts.Worlds;

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

        public void CreateCrime(){
            Crime crime = Instantiate(crimePrefab, transform);
            _world.state.crimes.Add(crime);
        }

    }
}