using UnityEngine;

namespace Assets.Scripts.UI
{
    public class MapToolsUi : MonoBehaviour
    {
        private Boot _boot;
        private UI _ui;
        public TooltipOnHoverUi tooltipOnHoverUi;

        public void Init(Boot boot, UI ui) {
            _boot = boot;
            _ui = ui;
            tooltipOnHoverUi.Init(boot, this);
        }
    }
}
