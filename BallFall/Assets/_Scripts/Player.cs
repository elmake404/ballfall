using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera _cam;
    [SerializeField]
    private Transform _innerCollider, _anchor;
    private Vector3 _startMosePos, _currentMosePos, _sizeObj,
        _sizeMax = Vector3.one,
        _sizeMin = new Vector3(0.3f, 0.3f, 0.3f);
    [SerializeField]
    private Rigidbody _rbMain;

    [SerializeField]
    private float _maxMass, _minMass, _changesSpeed;
    private float _factor;
    private void Start()
    {
        _sizeObj = transform.localScale;
        _cam = Camera.main;
        _factor = (_maxMass - _minMass) / ((_sizeMax.x - _sizeMin.x) * 10);
    }

    private void Update()
    {
        if (LevelManager.IsGameFlowe)
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
                ChangeOfSize((_startMosePos.y - _currentMosePos.y) * 4);
                _startMosePos = _currentMosePos;
            }
        }
        else
        {
            ChangeOfSize(1);
        }
    }
    private void FixedUpdate()
    {
        _innerCollider.position = transform.position;
        _innerCollider.localScale = transform.localScale;
        transform.localScale = Vector3.MoveTowards(transform.localScale, _sizeObj, _changesSpeed);
        _rbMain.mass = 2 + (_factor * ((transform.localScale.x - _sizeMin.x) * 10));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bonus")
        {
            other.GetComponentInParent<Bonus>().Activation(transform, _anchor);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Finish" )
        {
            LevelManager.IsGameFlowe=false;
            if (_rbMain.velocity == Vector3.zero)
            LevelManager.IsGameWin = true;
        }
    }
    private void ChangeOfSize(float change)
    {
        Vector3 size =
            new Vector3(_sizeObj.x + change, _sizeObj.y + change, _sizeObj.z + change);
        if (size.x > _sizeMax.x)
        {
            _sizeObj = _sizeMax;
            return;
        }
        else if (size.x < _sizeMin.x)
        {
            _sizeObj = _sizeMin;
            return;
        }
        _sizeObj = size;
    }
    public void OnFreeze()
    {
        _rbMain.constraints = RigidbodyConstraints.None;
    }
    public void Freeze()
    {
        _rbMain.constraints = RigidbodyConstraints.FreezePositionZ;
    }
}
