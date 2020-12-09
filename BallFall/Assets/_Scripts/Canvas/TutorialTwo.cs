using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTwo : MonoBehaviour
{
    private Vector3 _startMosePos, _currentMosePos;
    private Camera _cam;
    private void Start()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startMosePos = _cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            if (_startMosePos == Vector3.zero)
            {
                _startMosePos = _cam.ScreenToViewportPoint(Input.mousePosition);
            }

            _currentMosePos = _cam.ScreenToViewportPoint(Input.mousePosition);

            if (Mathf.Abs(_startMosePos.x - _currentMosePos.x) >= 0.05f)
            {
                PlayerPrefs.SetInt("FirstEntry", 1);

                gameObject.transform.parent.gameObject.SetActive(false);
                LevelManager.IsTutorial = false;
                Time.fixedDeltaTime = 0.02f;
                Time.timeScale = 1;
            }
        }
    }
}
