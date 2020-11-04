using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    private Vector3 _offSet;
    void Start()
    {
        _offSet = _player.position - transform.position;
    }

    void Update()
    {
        transform.position = _player.position-_offSet;
    }
}
