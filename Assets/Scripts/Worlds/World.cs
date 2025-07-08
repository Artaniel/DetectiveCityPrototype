namespace Assets.Scripts.Worlds
{
    using UnityEngine;

    public class World : MonoBehaviour
    {
        private Boot _boot;
        public WorldState state;

        public void Init(Boot boot) {
            _boot = boot;
            state.Init(boot, this);
        }
    }    
} 