using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField]
    private SkinnedMeshRenderer _skinnedMesh;
    [SerializeField]
    private Transform _beginning, _end;
    private float _magnitude;
    void Start()
    {
        _magnitude = (_end.position - _beginning.position).magnitude;
    }

    void FixedUpdate()
    {
        float BlendShape = 100 - (((_end.position - _beginning.position).magnitude * 100) / _magnitude);
        _skinnedMesh.SetBlendShapeWeight(0, BlendShape);
    }
}
