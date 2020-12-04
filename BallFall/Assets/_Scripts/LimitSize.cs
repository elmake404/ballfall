using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitSize : MonoBehaviour
{
    [SerializeField]
    private float _maxSize;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag =="Player")
    //    {
    //        Player.PlayerMain.ChangingTheMaximumSize(_maxSize);
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        Player.PlayerMain.ReturnToDefaultSize();
    //    }
    //}
}
