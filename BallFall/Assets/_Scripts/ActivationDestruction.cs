using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationDestruction : MonoBehaviour
{
    [SerializeField]
    private List<Destruction> _destructions;

    private float _count, _fourth;
    void Start()
    {
        _fourth = _destructions.Count / 4;
        _count += _fourth;
        StartCoroutine(Activation());
    }

    void Update()
    {

    }
    [ContextMenu("GetDestruction")]
    private void GetDestruction()
    {
        _destructions = new List<Destruction>();
        _destructions.AddRange(FindObjectsOfType<Destruction>());
    }
    private IEnumerator Activation()
    {
        for (int i = 0; i < _destructions.Count; i++)
        {
            _destructions[i].ActivationRB();
            if (i == _count)
            {
                _count = _fourth;
                yield return new WaitForSeconds(0.001f);
            }
        }
    }
}
