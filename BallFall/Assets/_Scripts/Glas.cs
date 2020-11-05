using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glas : MonoBehaviour
{
    [SerializeField]
    private GameObject _brokesGlas;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            _brokesGlas.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
