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
    private float _speed = 0.07f;
    void Start()
    {
        Vector3 PosPlayer = _player.transform.position;
        PosPlayer.x = transform.position.x;
        _offSet = PosPlayer - transform.position;
        _camPosZX = transform.position;
    }

    void FixedUpdate()
    {
        if (_player!=null)
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
}
