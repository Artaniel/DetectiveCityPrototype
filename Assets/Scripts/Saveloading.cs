using UnityEngine;
//using YG;

public class Saveloading : MonoBehaviour
{
    private Boot _boot;

    public void Init(Boot boot) {
        _boot = boot;
        Load();
    }

    public void Save() {/*
        YandexGame.savesData.level = _boot.session.levelNumber - 1;
        YandexGame.SaveProgress();*/
    }

    public void Load() {
        //_boot.session.LoadLevelFromSave(YandexGame.savesData.level);
    }
}
