using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilator : MonoBehaviour
{
    [SerializeField]
    private float _power;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.PlayerMain.Push(transform.up, _power,true);
        }
    }
}
