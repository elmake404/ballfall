using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiral : MonoBehaviour
{
    private float _posPlayerZ;
    private Player _player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _player = other.GetComponent<Player>();
            _player.OffFreeze();
            _posPlayerZ = _player.transform.position.z;
        }        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _player.Freeze();
            _player.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y,_posPlayerZ);
        }

    }
}
