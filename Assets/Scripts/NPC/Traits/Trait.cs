using UnityEngine;

namespace Assets.Scripts.NPC.Traits
{
    [CreateAssetMenu(menuName = "NPC/Trait", fileName = "Trait", order = 0)]
    public class Trait : ScriptableObject {
        public string displayName;
    }

}