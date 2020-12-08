using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    [SerializeField]
    private FixedJoint _joint;
    [SerializeField]
    private Rigidbody _rigidbody;

    void FixedUpdate()
    {
        if (_joint== null)
        {
            _rigidbody.mass = 0;
            gameObject.layer = 13;
            Destroy(gameObject,1);
            this.enabled = false;
        }
    }
    [ContextMenu("GetComponent")]
    private void GetJoint()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _joint = GetComponent<FixedJoint>();
    }
}
