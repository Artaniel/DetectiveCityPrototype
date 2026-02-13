using UnityEngine;

namespace Assets.Scripts.UI
{
    public class TooltipOnHoverUi : MonoBehaviour
    {
        private Boot _boot;
        private MapToolsUi _mapToolsUiui;

        public void Init(Boot boot, MapToolsUi mapToolsUiui) {
            _boot = boot;
            _mapToolsUiui = mapToolsUiui;
        }

        void Update() {
            
        }
    }
}