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
    [SerializeField]
    private bool _isNotGrow;
    [HideInInspector]
    public bool IsFrize;
    private void Start()
    {
        IsFrize = true;
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
        ControlSize();

        _innerCollider.position = transform.position;
        _innerCollider.localScale = transform.localScale;

        _rbMain.mass = 2 + (_factor * ((transform.localScale.x - _sizeMin.x) * 10));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bonus")
        {
            other.GetComponentInParent<Bonus>().Activation(transform, _anchor);
        }
        if (other.tag == "BoundaryWalls")
        {
            _isNotGrow = true;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Finish")
        {
            LevelManager.IsGameFlowe = false;
            _rbMain.angularVelocity = Vector3.zero;
            if (_rbMain.velocity.x <= (Vector3.one*0.1f).x
                &&_rbMain.velocity.x <= (Vector3.one*0.1f).x)
                LevelManager.IsGameWin = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BoundaryWalls")
        {
            _isNotGrow = false;
        }

    }
    private void ControlSize()
    {
        if (_isNotGrow)
        {
            if (_sizeObj.x > transform.localScale.x)
            {
                _sizeObj = transform.localScale;
            }
        }
        transform.localScale = Vector3.MoveTowards(transform.localScale, _sizeObj, _changesSpeed);
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
    public void OffFreeze()
    {
        IsFrize = false;
        _rbMain.constraints = RigidbodyConstraints.None;
    }
    public void Freeze()
    {
        IsFrize = true;
        _rbMain.constraints = RigidbodyConstraints.FreezePositionZ;
    }
}
