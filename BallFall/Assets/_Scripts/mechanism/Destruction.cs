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
    //private void Start()
    //{
    //    _mesh.enabled = false;
    //}
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

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "SpaceCamera")
    //    {
    //        _mesh.enabled = true;
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "SpaceCamera"&& gameObject.layer!=13)
    //    {
    //        _mesh.enabled = false;
    //    }

    //}
}
