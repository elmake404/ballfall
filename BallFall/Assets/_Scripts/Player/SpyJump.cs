using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyJump : MonoBehaviour
{
    private Player _player;
    [SerializeField]
    private Collider _colliderMain;
    void Start()
    {
        _player = Player.PlayerMain;
        transform.localScale = _player.GetSizeMin();
    }
    void LateUpdate()
    {
        if (_player.GetSize())
        {
            _colliderMain.enabled=true;
        }
        else
        {
            _colliderMain.enabled = false;
        }

        transform.position = _player.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer==12)
        {
            //_player.Jamp();
        }
    }

}
