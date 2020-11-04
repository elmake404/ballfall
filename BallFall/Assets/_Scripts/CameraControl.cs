using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    private Vector3 _offSet, _cameraPos;
    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    private float _speed;
    void Start()
    {
        //_cameraPos = transform.position;
        _offSet = _player.position - transform.position;
    }

    void FixedUpdate()
    {
        _cameraPos = (_player.position-_offSet);
        
        transform.position = Vector3.SmoothDamp(transform.position, _cameraPos, ref velocity, _speed);
    }
}
