using UnityEngine;
using Assets.Scripts;

public class InputService : MonoBehaviour
{
        private Boot _boot;

        public void Init(Boot boot) {
            _boot = boot;
        }
}
