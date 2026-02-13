namespace Assets.Scripts.UI
{
    using UnityEngine;

    public class UI : MonoBehaviour
    {
        private Boot _boot;
        public DebugToolsUi debugToolsUi;
        public PanelSwitcherUI panelSwitcherUI;
        public MapToolsUi mapToolsUi;

        public void Init(Boot boot) {
            _boot = boot;
            debugToolsUi.Init(boot, this);
            panelSwitcherUI.Init(boot, this);
            mapToolsUi.Init(boot, this);
        }

        public void TickUpdate(float deltatime) { 
            debugToolsUi.TickUpdate(deltatime);
        }
    }
}
