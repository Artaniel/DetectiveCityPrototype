using UnityEngine;
using Assets.Scripts;

public class Player : MonoBehaviour
{
        private Boot _boot;
        public PlayerMovement movement;

        public void Init(Boot boot) {
            _boot = boot;
            movement.Init(boot, this);
        }
}
