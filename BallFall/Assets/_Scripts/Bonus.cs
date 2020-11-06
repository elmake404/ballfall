using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rbMain;
    [SerializeField]
    private Collider _collider;
    private Transform _player,_anchorPlayer;

    void LateUpdate()
    {
        if (_player!=null)
        {
            transform.localScale = _player.localScale;
            if (!LevelManager.IsGameWin)
            {
                ControlPosition();
            }
        }
    }
    private void ControlPosition()
    {
        float Mag = (_anchorPlayer.position - _player.position).magnitude;
        float MagMain = (transform.position - _player.position).magnitude;
        if (MagMain > Mag)
        {
            transform.position = _player.position + (transform.position - _player.position).normalized * Mag;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Finish")
        {
            _rbMain.AddForce(Vector3.down*60);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Finish")
        {
            _rbMain.velocity/=4;
        }
    }
    public void Activation(Transform player,Transform anchor)
    {
        _anchorPlayer = anchor;
        _player = player;
        transform.position = _player.position;
        transform.localScale = _player.localScale;
        gameObject.layer = 9;
        _collider.gameObject.layer= 9;
        _collider.isTrigger = false;
        _rbMain.isKinematic = false;
    }
}
