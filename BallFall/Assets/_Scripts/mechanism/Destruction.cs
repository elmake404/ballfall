using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    [SerializeField]
    private FixedJoint _joint;

    void FixedUpdate()
    {
        if (_joint== null)
        {
            Destroy(gameObject,1);
            this.enabled = false;
        }
    }
    [ContextMenu("GetJoint")]
    private void GetJoint()
    {
        _joint = GetComponent<FixedJoint>();
    }
}
