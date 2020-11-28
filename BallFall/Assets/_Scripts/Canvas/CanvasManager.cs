using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _menuUi, _InGameUi, _winUI, _loseUI;
    [SerializeField]
    private Image _progressBar;
    [SerializeField]
    private Text _texLevelWin, _texLevelGameCurrent, _texLevelGameTarget;
    private Player _player;

    private float _maxDistance;
    private void Start()
    {
        _player = Player.PlayerMain;

        _maxDistance = _player.GetMagnitudeToFinish();

        if (PlayerPrefs.GetInt("Level") <= 0)
        {
            PlayerPrefs.SetInt("Level", 1);
        }

        _texLevelWin.text = "Level " + PlayerPrefs.GetInt("Level");
        _texLevelGameCurrent.text = PlayerPrefs.GetInt("Level").ToString();
        _texLevelGameTarget.text = (PlayerPrefs.GetInt("Level") + 1).ToString();

        if (!LevelManager.IsEntrance)
        {
            _menuUi.SetActive(true);
        }
        else
        {
            FacebookManager.Instance.LevelStart(PlayerPrefs.GetInt("Level"));
        }

        FacebookManager.Instance.GameStart();

    }

    private void FixedUpdate()
    {
        if (LevelManager.IsStartGame && !_InGameUi.activeSelf)
        {
            _InGameUi.SetActive(true);
        }
        if (LevelManager.IsGameWin && !_winUI.activeSelf)
        {
            _InGameUi.SetActive(false);
            _winUI.SetActive(true);
            FacebookManager.Instance.LevelWin(PlayerPrefs.GetInt("Level"));
            PlayerPrefs.SetInt("Scenes", PlayerPrefs.GetInt("Scenes") + 1);
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        }
    }
    private void LateUpdate()
    {
        float mag = _player.GetMagnitudeToFinish();
        float fillAmount =  (_maxDistance - mag) / _maxDistance;

        if (_progressBar.fillAmount < fillAmount)
            _progressBar.fillAmount = fillAmount;
    }
}
