using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player PlayerMain;

    private Camera _cam;
    [SerializeField]
    private Transform _innerCollider, _anchor;
    [SerializeField]
    private Vector3 _finishPos;
    private Vector3 _goOffMosePos, _startMosePos, _currentMosePos, _sizeObj,
        _currentSizeMax = Vector3.one,
        _sizeMax = Vector3.one,
        _sizeMin = new Vector3(0.3f, 0.3f, 0.3f),
    _direcrionVector = Vector3.zero;
    [SerializeField]
    private Rigidbody _rbMain;

    [SerializeField]
    private float _maxMass, _minMass, _destructionMass, _changesSpeed, _speed;
    private float _factor;
    [SerializeField]
    private bool _isNotGrow;
    private bool _isMaxMass, _isDestructionMass;

    [HideInInspector]
    public bool IsFrize;
    [HideInInspector]
    public float MaxSize = 1;

    private void Awake()
    {
        PlayerMain = this;
        IsFrize = true;

        if (!LevelManager.IsEntrance)
        {
            gameObject.SetActive(false);
        }
        else
        {
            LevelManager.IsStartGame = true;
        }
    }
    private void Start()
    {
        _sizeObj = transform.localScale;
        _cam = Camera.main;
        _factor = (_maxMass - _minMass) / ((_sizeMax.x - _sizeMin.x) * 10);
    }
    private void Update()
    {
        if (LevelManager.IsStartGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _goOffMosePos = _cam.ScreenToViewportPoint(Input.mousePosition);
                _startMosePos = _cam.ScreenToViewportPoint(Input.mousePosition);
            }
            else if (Input.GetMouseButton(0))
            {
                ChangeOfSize(1);
                _isMaxMass = true;
                if (_goOffMosePos == Vector3.zero)
                {
                    _startMosePos = _cam.ScreenToViewportPoint(Input.mousePosition);
                    _goOffMosePos = _cam.ScreenToViewportPoint(Input.mousePosition);
                }
                _currentMosePos = _cam.ScreenToViewportPoint(Input.mousePosition);

                if (Mathf.Abs(_startMosePos.x - _currentMosePos.x) >= 0.05f)
                {
                    if (Mathf.Abs((_currentMosePos.x - _startMosePos.x) * 3) > 1)
                    {
                        float xStart = ((_currentMosePos.x - _startMosePos.x) > 0 ? 0.3f : -0.3f);
                        _startMosePos.x = _currentMosePos.x - xStart;
                    }

                    float X = ((_currentMosePos.x - _startMosePos.x) * 3) * _speed;
                    _direcrionVector = new Vector3(X, 0, 0);
                }
                else
                {
                    _direcrionVector = _rbMain.velocity;
                }
            }
            else
            {
                _direcrionVector = _rbMain.velocity;
                ChangeOfSize(-1);
                _isMaxMass = false;
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
        _direcrionVector.y = _rbMain.velocity.y;
        _rbMain.velocity = _direcrionVector;
        _innerCollider.position = transform.position;
        _innerCollider.localScale = transform.localScale;

        if (_isDestructionMass)
        {
            _rbMain.mass = _destructionMass;
        }
        else if (_isMaxMass)
        {
            _rbMain.mass = _maxMass;
        }
        else
        {
            _rbMain.mass = _minMass;
        }
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
        if (other.tag == "Finish")
        {
            LevelManager.IsStartGame = false;
            StartCoroutine(FinishGame());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BoundaryWalls")
        {
            _isNotGrow = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Spikes")
        {
            LevelManager.IsStartGame = false;
            LevelManager.IsGameLose = true;
            Destroy(_innerCollider.gameObject);
            Destroy(gameObject);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag== "Destruction")
        {
            _isDestructionMass = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Destruction")
        {
            _isDestructionMass = false;
        }

    }
    private IEnumerator FinishGame()
    {
        _rbMain.isKinematic = true;
        _rbMain.velocity = Vector3.zero;

        while (transform.position != _finishPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _finishPos, 0.05f);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.5f);

        LevelManager.IsGameWin = true;
        _rbMain.velocity = Vector3.zero;

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

        if (LevelManager.IsStartGame)
        {
            if (_sizeObj.x > _currentSizeMax.x && _sizeObj.x > transform.localScale.x)
            {
                _sizeObj = transform.localScale;
            }
            transform.localScale = Vector3.MoveTowards(transform.localScale, _sizeObj, _changesSpeed);
        }
        else
            transform.localScale = Vector3.MoveTowards(transform.localScale, _sizeObj, _changesSpeed * 2);
    }
    private void ChangeOfSize(float change)
    {
        //Vector3 size =
        //         new Vector3(_sizeObj.x + change, _sizeObj.y + change, _sizeObj.z + change);

        if (change > 0)
        {
            _sizeObj = _sizeMax;
            return;
        }
        else if (change < 0)
        {
            _sizeObj = _sizeMin;
            return;
        }
        //_sizeObj = size;
    }
    [ContextMenu("FindFinishPos")]
    private void FindFinishPos()
    {
        _finishPos = GameObject.FindWithTag("FinishPos").transform.position;
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
    public void Push(Vector3 direction, float power, bool weightCheck)
    {
        if (weightCheck)
        {
            if (_rbMain.mass < 15)
            {
                _rbMain.AddForce(direction * power, ForceMode.Acceleration);
            }
        }
        else
        {
            _rbMain.AddForce(direction * power, ForceMode.Acceleration);
        }
    }
    public void ChangingTheMaximumSize(float newMaxSize)
    {
        _currentSizeMax = new Vector3(newMaxSize, newMaxSize, newMaxSize);
    }
    public void ReturnToDefaultSize()
    {
        _currentSizeMax = _sizeMax;
    }
    public float GetMagnitudeToFinish()
    {
        return (_finishPos - transform.position).sqrMagnitude;
    }
    public bool GetSize()
    {
        return transform.localScale.x <= _sizeMin.x;
    }
    public Vector3 GetSizeMin()
    {
        return _sizeMin;
    }
}
