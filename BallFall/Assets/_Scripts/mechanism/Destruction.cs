using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _mesh;
    [SerializeField]
    private FixedJoint _joint;
    [SerializeField]
    private Rigidbody _rigidbody;

    private float _breakForce, _breakTorque;
    private void Awake()
    {
        _breakForce = _joint.breakForce;
        _breakTorque = _joint.breakTorque;
        _joint.breakForce = float.PositiveInfinity;
        _joint.breakTorque = float.PositiveInfinity;
        StartCoroutine(ActivationJoint());

    }
    void FixedUpdate()
    {
        if (_joint== null)
        {
            _rigidbody.mass = 0;
            gameObject.layer = 13;
            Destroy(gameObject,0.5f);
            this.enabled = false;
        }
    }
    [ContextMenu("GetComponent")]
    private void GetJoint()
    {
        _mesh = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
        _joint = GetComponent<FixedJoint>();
    }
    private IEnumerator ActivationJoint()
    {
        yield return new WaitForSeconds(0.5f);
        _joint.breakForce = _breakForce;
        _joint.breakTorque = _breakTorque;

    }
    public void ActivationRB()
    {
        _rigidbody.isKinematic = false;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "SpaceCamera")
    //    {
    //        _rigidbody.isKinematic = false;
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "SpaceCamera" )
    //    {
    //        _rigidbody.isKinematic = true;
    //    }

    //}
}
