using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    private Vector3 _offSet, _cameraPos,_camPosZX;
    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    private float _speed;
    void Start()
    {
        _offSet = _player.transform.position - transform.position;
        _camPosZX = transform.position;
    }

    void FixedUpdate()
    {
        if (_player.IsFrize)
        {
            _cameraPos = _camPosZX;
            _cameraPos.y = (_player.transform.position - _offSet).y;
            transform.position = Vector3.SmoothDamp(transform.position, _cameraPos, ref velocity, _speed);
        }
        else
        {
            _cameraPos = (_player.transform.position - _offSet);
            transform.position = Vector3.SmoothDamp(transform.position, _cameraPos, ref velocity, _speed);
        }
    }
}
