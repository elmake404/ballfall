using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager CanvasMain;

    [SerializeField]
    private GameObject _menuUi, _InGameUi, _winUI, _loseUI;
    [SerializeField]
    private Image _progressBar;
    [SerializeField]
    private Text _texLevelWin, _texLevelGameCurrent, _texLevelGameTarget;
    private Player _player;
    [SerializeField]
    private Image[] _stars;


    private float _maxDistance, _fillStars, _numberStars, _receivedStars;
    private bool _isWin = false;
    private int _namberBonus, _namberArreySrars = 0;
    private void Start()
    {
        CanvasMain = this;
        _namberBonus = LevelManager.Namberbonus;
        LevelManager.Namberbonus = 0;
        _fillStars = 3f / _namberBonus;

        Debug.Log(_namberBonus);
        Debug.Log(_fillStars);

        //PlayerPrefs.SetInt("Scenes", 11);
        //PlayerPrefs.SetInt("Level", 11);
        //PlayerPrefs.SetInt("FirstEntry", 0);

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(LevelManager.NamberActivationBonus);
            Debug.Log(LevelManager.IsGameWin);
        }

        if (_numberStars < _receivedStars)
        {
            _numberStars += 0.05f;

            _stars[_namberArreySrars].fillAmount += 0.05f;

            if (_stars[_namberArreySrars].fillAmount >= 1 && _namberArreySrars < _stars.Length - 1)
            {
                _namberArreySrars++;
            }
        }

        if (LevelManager.IsStartGame && !_InGameUi.activeSelf && !LevelManager.IsTutorial)
        {
            _InGameUi.SetActive(true);
        }

        if (LevelManager.IsGameWin && !_winUI.activeSelf)
        {
            _InGameUi.SetActive(false);
            _winUI.SetActive(true);
            _isWin = true;

            ResidentSaved();

            FacebookManager.Instance.LevelWin(PlayerPrefs.GetInt("Level"));

            PlayerPrefs.SetInt("Scenes", PlayerPrefs.GetInt("Scenes") + 1);
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        }

        if (LevelManager.IsGameLose && !_loseUI.activeSelf)
        {
            _InGameUi.SetActive(false);
            _loseUI.SetActive(true);
            FacebookManager.Instance.LevelFail(PlayerPrefs.GetInt("Level"));
        }
    }
    private void LateUpdate()
    {
        if (!LevelManager.IsGameLose)
        {
            float mag = _player.GetMagnitudeToFinish();
            float fillAmount = (_maxDistance - mag) / _maxDistance;

            if (_progressBar.fillAmount < fillAmount)
                _progressBar.fillAmount = fillAmount;
        }
    }
    public void ResidentSaved()
    {
        _receivedStars = LevelManager.NamberActivationBonus * _fillStars;
        LevelManager.NamberActivationBonus = 0;
    }

}
