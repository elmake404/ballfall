using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField]
    private ConfigurableJoint[] _configurableJoints;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private IEnumerator Destruction()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < _configurableJoints.Length; i++)
        {
            if(_configurableJoints[i]!=null)
            {
                Destroy(_configurableJoints[i].gameObject,Random.Range(0.5f,1.5f));
                Destroy(_configurableJoints[i]);

            }
        }
        yield return new WaitForSeconds(1);
        //Destroy(gameObject);
    }
    public void StartDestruction()
    {
        StartCoroutine(Destruction());
    }
}
