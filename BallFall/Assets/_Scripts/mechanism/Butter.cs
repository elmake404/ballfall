using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butter : MonoBehaviour
{
    [SerializeField]
    private float _maxDistens,_mag;
    private Vector3 _startPos;
    void Start()
    {
        _startPos = transform.position;
    }

    void FixedUpdate()
    {
        _mag = (transform.position - _startPos).sqrMagnitude;
        if ((transform.position - _startPos).sqrMagnitude > _maxDistens)
        {
            Destroy(gameObject);
        }
    }
}
