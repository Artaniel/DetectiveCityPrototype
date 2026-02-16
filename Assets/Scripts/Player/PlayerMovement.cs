using Assets.Scripts;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Boot _boot;
    private Player _player;
    public void Init(Boot boot, Player player) {
        _boot = boot;
        _player = player;
    }
}
