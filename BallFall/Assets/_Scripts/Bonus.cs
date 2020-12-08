using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _meshMain;
    [SerializeField]
    private Material _oldMaterial, _newMaterial;
    [SerializeField]
    private Rigidbody _rbMain;
    [SerializeField]
    private Collider _collider;
    private Transform _player, _anchorPlayer;

    private bool _isLevelFalse;

    void LateUpdate()
    {
        if (_player != null)
        {
            transform.localScale = _player.localScale;
            if (!LevelManager.IsGameWin)
            {
                ControlPosition();
            }
        }
        else if (_rbMain.isKinematic && LevelManager.IsGameLose)
        {
            _meshMain.material = _oldMaterial;
            gameObject.layer = 0;
            _collider.gameObject.layer = 0;
            transform.localScale = Vector3.one;
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
            gameObject.layer = 11;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Finish")
        {
            gameObject.layer = 10;
            _meshMain.material = _oldMaterial;

            _rbMain.velocity = Vector3.zero;
        }
    }
    public void Activation(Transform player, Transform anchor)
    {
        _meshMain.material = _newMaterial;
        _anchorPlayer = anchor;
        _player = player;
        transform.position = _player.position;
        transform.localScale = _player.localScale;
        gameObject.layer = 9;
        _collider.gameObject.layer = 9;
        _collider.isTrigger = false;
        _rbMain.isKinematic = false;
    }
}
