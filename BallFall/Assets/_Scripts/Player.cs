using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera _cam;
    private Vector3 _startMosePos, _currentMosePos,
        _sizeMax = Vector3.one,
        _sizeMin = new Vector3(0.3f, 0.3f, 0.3f);
    [SerializeField]
    private Rigidbody _rbMain;

    [SerializeField]
    private float _maxMass, _minMass;
    private float _factor;
    void Start()
    {
        _cam = Camera.main;
        _factor = (_maxMass - _minMass) / ((_sizeMax.x - _sizeMin.x) * 10);
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
            ChangeOfSize((_startMosePos.y - _currentMosePos.y) * 2);
            _startMosePos = _currentMosePos;
        }
    }
    private void ChangeOfSize(float change)
    {
        Vector3 size =
            new Vector3(transform.localScale.x + change, transform.localScale.y + change, transform.localScale.z + change);
        if (size.x > _sizeMax.x)
        {
            transform.localScale = _sizeMax;
            _rbMain.mass = _maxMass;
            return;
        }
        else if (size.x < _sizeMin.x)
        {
            transform.localScale = _sizeMin;
            _rbMain.mass = _minMass;
            return;
        }
        _rbMain.mass = 2 + (_factor * ((size.x - _sizeMin.x) * 10));
        transform.localScale = size;
    }
}
