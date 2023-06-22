using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainControl : MonoBehaviour
{
    //private float rotation = 26.812f;根据这个角度的正切决定方向
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-1, -0.505f) * 50 * Time.deltaTime);
        Destroy(gameObject,2);
    }
}
