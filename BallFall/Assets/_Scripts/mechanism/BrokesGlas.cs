using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokesGlas : MonoBehaviour
{
    [SerializeField]
    private float _penetrationMass;
    [SerializeField]
    private Rigidbody _rbMain;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player"
            && collision.gameObject.GetComponent<Rigidbody>().mass>= _penetrationMass)
        {
            transform.SetParent(null);
            _rbMain.isKinematic = false;
            Destroy(gameObject,1);
        }
    }
}
