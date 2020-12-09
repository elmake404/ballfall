using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    [SerializeField]
    private GameObject[] _tutorials;

    private bool _isFirstPressing;
    void Start()
    {
        _tutorials[0].SetActive(true);
        _tutorials[1].SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_isFirstPressing)
            {
                _isFirstPressing = true;
                _tutorials[0].SetActive(false);
                //_tutorials[1].SetActive(true);
                Time.fixedDeltaTime = 0.02f;
                Time.timeScale = 1;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if(_isFirstPressing)
            ActivationTutorialTwo();
        }
    }
    private void FixedUpdate()
    {
        if (Player.PlayerMain.transform.localScale.x>=1)
        {
            ActivationTutorialTwo();
        }
    }
    private void ActivationTutorialTwo()
    {
        if (!_tutorials[1].activeSelf)
        {
            _tutorials[1].SetActive(true);
            Time.fixedDeltaTime = 0;
            Time.timeScale = 0;
        }
    }
}
