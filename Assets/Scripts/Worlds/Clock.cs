namespace Assets.Scripts.Worlds
{
    using UnityEngine;

    public class Clock : MonoBehaviour
    {
        private Boot _boot;
        private World _world;
        private WorldState _state;

        public float minuteTickInterval = 1f;
        public float timeScale = 1f;
        public float tickTimer;

        public void Init(Boot boot, World world) {
            _boot = boot;
            _world = world;
            _state = world.state;
        }

        public void ManualFixedUpdate() {
            tickTimer += Time.fixedDeltaTime * timeScale;
            if (tickTimer >= minuteTickInterval) {
                tickTimer -= minuteTickInterval;
                _state.currentTimeInMinutes++;
                MinuteTick();
            }
        }

        private void MinuteTick() {
            _world.npcFactory.TickUpdate(1f);
        }
    }
}