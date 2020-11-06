using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiral : MonoBehaviour
{
    private float _posPlayerZ;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.PlayerMain.OffFreeze();
            _posPlayerZ = Player.PlayerMain.transform.position.z;
        }        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.PlayerMain.Freeze();
            Player.PlayerMain.transform.position = new Vector3(Player.PlayerMain.transform.position.x, Player.PlayerMain.transform.position.y,_posPlayerZ);
        }

    }
}
