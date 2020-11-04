using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spy : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private GameObject Collider;
   
    void Start()
    {
        transform.position = _player.position;
        transform.localScale = _player.localScale;
    }
    private void FixedUpdate()
    {
        if (LevelManager.IsGameWin)
        {
            Collider.SetActive(false);
        }    
    }

    void LateUpdate()
    {
        transform.position = _player.position;
        transform.localScale = _player.localScale;
    }
}
