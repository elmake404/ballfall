using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelBottom : MonoBehaviour
{
    [SerializeField]
    private Image _activation, _offActivation;
    [SerializeField]
    private int _level;
    [SerializeField]
    private Image[] _stars;
    private float _numberStars;
    private int _namberArreySrars = 0;
    private string _activationLevel;
    private void Awake()
    {
        _activationLevel = "ActivationLevel" + _level;

        if (PlayerPrefs.GetFloat(_activationLevel) <= 0)
        {
            _activation.enabled = false;
            _offActivation.enabled = true;
            for (int i = 0; i < _stars.Length; i++)
            {
                _stars[i].transform.parent.gameObject.SetActive(false);
            }
        }
        else
        {
            _activation.enabled = true;
            _offActivation.enabled = false;
        }

    }
    void Start()
    {
        string receivedStars = "receivedStars" + _level;

        while (_numberStars < PlayerPrefs.GetFloat(receivedStars))
        {
            _numberStars += 0.05f;

            _stars[_namberArreySrars].fillAmount += 0.05f;

            if (_stars[_namberArreySrars].fillAmount >= 1 && _namberArreySrars < _stars.Length - 1)
            {
                _namberArreySrars++;
            }
        }
    }
    public void LoadLevel()
    {
        if (PlayerPrefs.GetFloat(_activationLevel) > 0)
        {
            if (_level < SceneManager.sceneCountInBuildSettings - 1)
            {
                PlayerPrefs.SetInt("Scenes", _level);
                PlayerPrefs.SetInt("Level", _level);

                SceneManager.LoadScene(_level);
            }
            else
            {
                PlayerPrefs.SetInt("Scenes", 1);
                PlayerPrefs.SetInt("Level", 1);

                SceneManager.LoadScene(PlayerPrefs.GetInt("Scenes"));
            }
        }
    }

}
