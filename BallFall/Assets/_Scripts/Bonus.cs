﻿using System.Collections;
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
    private void Awake()
    {
        LevelManager.Namberbonus++;
    }
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
        if (other.tag == "ColliderBonus"&& _collider.gameObject.layer!=0)
        {
          _collider.gameObject.layer = 10;
        }

        //if (other.tag == "BonusBottle")
        //{
        //    Debug.Log(LevelManager.NamberActivationBonus);
        //    CanvasManager.CanvasMain.ResidentSaved();
        //    LevelManager.NamberActivationBonus--;

        //    _collider.gameObject.layer = 9;
        //    _meshMain.material = _oldMaterial;

        //    _rbMain.velocity = Vector3.zero;
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BonusBottle")
        {
            StartCoroutine(GetLayer());

            enabled = false;
            _meshMain.material = _oldMaterial;
            _rbMain.velocity = Vector3.zero;
        }
    }
    private IEnumerator GetLayer()
    {
        yield return new WaitForSeconds(Random.Range(0.1f,0.6f));
        _collider.gameObject.layer = 0;
    }
    public void Activation(Transform player, Transform anchor)
    {
        LevelManager.NamberActivationBonus++;
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
