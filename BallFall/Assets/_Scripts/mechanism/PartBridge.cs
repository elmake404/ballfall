using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBridge : MonoBehaviour
{
    [SerializeField]
    private Bridge _bridge;
    [SerializeField]
    private ConfigurableJoint _joint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_joint==null)
        {
            _bridge.StartDestruction();
            Destroy(gameObject,1);
            enabled = false;
        }
    }
    [ContextMenu("GetBridge")]
    private void GetBridge()
    {
        _bridge = GetComponentInParent<Bridge>();
        _joint = GetComponent<ConfigurableJoint>();
    }
}
