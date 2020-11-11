using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedUVs : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 0.5F;
    [SerializeField]
    private Renderer rend;
    void FixedUpdate()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
