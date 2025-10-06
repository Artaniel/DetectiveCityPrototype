namespace Assets.Scripts.UI
{
    using UnityEngine;

    public class UI : MonoBehaviour
    {
        private Boot _boot;
        public DebugToolsUi debugToolsUi;

        public void Init(Boot boot) {
            _boot = boot;
            debugToolsUi.Init(boot, this);
        }
    }
}
