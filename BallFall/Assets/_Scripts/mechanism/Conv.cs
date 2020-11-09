using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conv : MonoBehaviour
{
    [SerializeField]
    private float _power;
    [SerializeField]
    private Vector3 _direction;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.PlayerMain.Push(_direction, _power, false);
        }
    }
}
